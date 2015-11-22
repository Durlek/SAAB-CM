var assert  = require('assert');
var request = require('request').defaults({baseUrl: 'http://localhost:8732/'});

const EXAMPLE_LCD = {
    Data: []
,   Description: "foobar"
,   DetectionMode: 0
,   Id: ""
,   Name: ""
,   Position: null
,   State: {
        AudioFault:             false
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
    ,   HealthCheckFailur:      false
    ,   InitialSelfTest:        false
    ,   InitialSeltTestFailed:  false
    ,   LowBattery:             false
    ,   LowSieve:               false
    ,   PTOutOfRange:           false
    ,   TicAlert:               false
    ,   TicMode:                false
    }
}

const EXAMPLE_AP2CE = {
    Data: null
,   Description: "foobar"
,   Id: ""
,   Name: ""
,   Position: null
,   State: null
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
                ,   body: {}
                ,   json: true
                }, function(err, res, body) {
                    if (err) throw err;
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
                        body.Id = ""; // Can't test exact id
                        deepEq(body, EXAMPLES[sensor]);
                        done();
                    });
                });
            })
        });

        describe('#Delete', function() {
            it('should delete created sensor', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor]
                ,   json: true
                }, function (err, res, body) {
                
                if (err) throw err;
                request({
                    url: 'sensors/' + sensor + '/' + res.headers.location
                ,   method: 'DELETE'
                }, function (err, res, body) {
                
                if (err) throw err;
                request({
                    url: 'sensors/' + sensor + '/' + res.headers.location
                ,   method: 'GET'
                ,   json: true
                }, function (err, res, body) {

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