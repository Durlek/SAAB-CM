var assert  = require('assert');
var request = require('request').defaults({baseUrl: 'http://localhost:8732/'});
var http    = require('http');

const EXAMPLE_LCD = {
    Data: [
        {
            BarCount: 5
        ,   VolumeConcentration: 20
        ,   SubstanceIndex: 0
        }
    ]
,   Description: "foobar"
,   DetectionMode: 0
,   Name: ""
,   Position: {Altitude: 0, Latitude: 1, Longitude: 2}
,   State: {
        AudioFault:             true
    ,   CRAboveLimit:           false
    ,   ChangeBattery:          false
    ,   ChangeSievePack:        false
    ,   CodeChecksumError:      false
    ,   CoronaBurnOff:          false
    ,   EEPROMChecksumError:    false
    ,   FanCAboveLimit:         false
    ,   FatalError:             false
    ,   GAlert:                 false
    ,   GHighDoseAlert:         false
    ,   GMediumDoseAlert:       false
    ,   HAlert:                 false
    ,   HHighDoseAlert:         false
    ,   HTOutSideLimits:        false
    ,   HealthCheckFailure:     false
    ,   InitialSelfTest:        false
    ,   InitialSelfTestFailure: false
    ,   LowBattery:             false
    ,   LowSieve:               false
    ,   PTOutOfRange:           false
    ,   TICAlert:               false
    ,   TICMode:                false
    }
}

const EXAMPLE_AP2CE = {
    Data: [
        {
            BarCount: 5
        ,   VolumeConcentration: 20
        }
    ]
,   Description: "foobar"
,   Name: ""
,   Position: {Altitude: 3, Latitude: 4, Longitude: 5}
,   State: {
        BatteryLow: false
    ,   DetectorReady: false
    ,   DeviceFault: false
    ,   HydrogenTankEmpty: false
    ,   Purge: true
    }
}

const EXAMPLES = {lcd: EXAMPLE_LCD, ap2ce: EXAMPLE_AP2CE};
const SENSORS  = ['lcd', 'ap2ce'];

function eq(v1, v2, msg) {
    assert.strictEqual(v1, v2, msg + ' (' + v1 + ' != ' + v2 + ')');
}

function deepEq(v1, v2, msg) {
    assert.deepStrictEqual(v1, v2, msg);
}

function ok(v, msg) {
    assert.ok(v, msg);
}

SENSORS.forEach(function (sensor) {
    describe(sensor, function() {
        describe('#Create', function() {
            it('should return id in header when created', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor]
                ,   json: true
                }, function(err, res, body) {

                if (err) throw err;
                ok(res.headers.location, 'Location header should exist');
                ok(/^[0-9a-z\-_]+$/.test(res.headers.location), 'Wrong id format');
                done();
                });
            });
        });

        describe('#Read', function() {
            it('should access created sensor', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor]
                ,   json: true
                }, function (err, res, body) {
                
                if (err) throw err;
                request({
                    url: 'sensors/' + sensor + '/' + res.headers.location
                ,   method: 'GET'
                ,   json: true
                }, function (err, res, body) {
               
                if (err) throw err;
                ok(/^[0-9a-z\-_]+$/.test(body.Id), 'Wrong id format');
                delete body.Id; // Can't test exact id
                delete body.Parent; // Can't test parent id either
                deepEq(body, EXAMPLES[sensor]);
                done();
               
                });
                });
            })
        });

        describe('#Update', function() {
            it('should update attribute', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor]
                ,   json: true
                }, function (err, res, body) {

                if (err) throw err;
                var id = res.headers.location;
                // dirty copy, 
                // works since we only are working with json object anyway
                var sensorObject = JSON.parse(JSON.stringify(EXAMPLES[sensor]));
                sensorObject.Description = "foobaz";
                sensorObject.Data[0].BarCount = 1;

                request({
                    url: 'sensors/' + sensor + '/' + id
                ,   method: 'PUT'
                ,   body: sensorObject
                ,   json: true
                }, function (err, res, body) {

                eq(res.statusCode, 200);

                if (err) throw err;
                request({
                    url: 'sensors/' + sensor + '/' + id
                ,   method: 'GET'
                ,   json: true
                }, function (err, res, body) {

                eq(body.Description, sensorObject.Description);
                eq(sensorObject.Data[0].BarCount, 1);
                done();

                });
                });
                });
            });
        });

        describe('#Delete', function() {
            it('should delete created sensor', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor]
                ,   json: true
                }, function(err, res, body) {
                
                if (err) throw err;
                ok(res.headers.location, 'Location header should exist');
                request({
                    url: 'sensors/' + sensor + '/' + res.headers.location
                ,   method: 'DELETE'
                }, function(err, res, body) {
                
                if (err) throw err;
                request({
                    url: 'sensors/' + sensor + '/' + res.headers.location
                ,   method: 'GET'
                ,   json: true
                }, function(err, res, body) {

                if (err) throw err;
                eq(res.statusCode, 404, '[Get] should return 404 when deleted')
                done();

                });
                });
                });
            });
        });
    });
});

describe('Connection test', function() {
    it('should return magic number', function(done) {
        request({
            url: 'check'
        ,   method: 'GET'
        }, function(err, res, body) {

        if (err) throw err;
        eq(body, '123');
        done();

        });
    });
});