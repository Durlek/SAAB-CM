var assert  = require('assert');
var request = require('request').defaults({baseUrl: 'http://localhost:8732/'});
var http    = require('http');

const EXAMPLE_LCD = {
    Data: [
        {
            BarCount: 0
        ,   VolumeConcentration: 0
        ,   SubstanceIndex: 0
        ,   SubstanceCategory: 'G'
        },
        {
            BarCount: 0
        ,   VolumeConcentration: 0
        ,   SubstanceIndex: 0
        ,   SubstanceCategory: 'H'
        }
    ]
,   Description: ""
,   DetectionMode: 0
,   Name: ""
,   Position: {Altitude: 0, Latitude: 1, Longitude: 2}
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
    ,   HealthCheckFailure:     false
    ,   InitialSelfTest:        false
    ,   InitialSelfTestFailure: false
    ,   LowBattery:             false
    ,   LowSieve:               false
    ,   PTOutOfRange:           false
    ,   TICAlert:               false
    ,   TICMode:                false
    ,   AudibleAlarm:           false
    }
}

const EXAMPLE_AP2CE = {
    Data: [{
        BarCount: 0
        , VolumeConcentration: 0
        , SubstanceCategory: 'G'
        },
        {
            BarCount: 0
        ,   VolumeConcentration: 0
        ,   SubstanceCategory: 'H'
        }]
,   Description: ""
,   Name: ""
,   Position: {Altitude: 3, Latitude: 4, Longitude: 5}
,   State: {
        BatteryLow: false
    ,   DetectorReady: false
    ,   DeviceFault: false
    ,   HydrogenTankEmpty: false
    ,   Purge: false
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
                ,   body: EXAMPLES[sensor].Position
                ,   json: true
                }, function (err, res, body) {

                    if (err) throw err;
                    ok(res.headers.location, 'Location header should exist');
                    ok(/^[0-9a-z\-_]+$/.test(res.headers.location), 'Wrong id format');
                    done();
                });
            });

            it('should return id in header when created without position', function (done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: null
                ,   json: true
                }, function (err, res, body) {

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
                ,   body: EXAMPLES[sensor].Position
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
            it('should update position', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor].Position
                ,   json: true
                }, function (err, res, body) {

                    if (err) throw err;
                    var id = res.headers.location;

                    // dirty copy, 
                    // works since we only are working with json object anyway
                    var sensorObject = JSON.parse(JSON.stringify(EXAMPLES[sensor]));

                    sensorObject.Position.Altitude++;
                    sensorObject.Description = null;
                    sensorObject.Data = null;
                    sensorObject.Name = null;
                    sensorObject.State = null;

                    if (sensor === 'lcd') {
                        sensorObject.DetectionMode = 3;
                    }

                    request({
                        url: 'sensors/' + sensor + '/' + id
                    ,   method: 'PUT'
                    ,   body: /*sensorObject*/ {Position: sensorObject.Position}
                    ,   json: true
                    }, function (err, res, body) {

                        if (err) throw err;
                        eq(res.statusCode, 200);
                        request({
                            url: 'sensors/' + sensor + '/' + id
                        ,   method: 'GET'
                        ,   json: true
                        }, function (err, res, body) {

                            deepEq(body.Position, sensorObject.Position);
                            if (sensor === 'lcd') {
                                eq(body.DetectionMode, EXAMPLE_LCD.DetectionMode)
                            }
                            done();
                        });
                    });
                });
            });

            // Welcome to callback hell
            if (sensor === 'lcd') {
                const NEW_DETECTION_MODE = 2;

                it('should update detectionmode', function (done) {
                    request({
                        url: 'sensors/' + sensor
                    ,   method: 'POST'
                    ,   body: EXAMPLES[sensor].Position
                    ,   json: true
                    }, function (err, res, body) {

                        if (err) throw err;
                        var id = res.headers.location;

                        request({
                            url: 'sensors/' + sensor + '/' + id
                        ,   method: 'PUT'
                        ,   body: { DetectionMode: NEW_DETECTION_MODE }
                        ,   json: true
                        }, function (err, res, body) {

                            if (err) throw err;
                            eq(res.statusCode, 200);
                            request({
                                url: 'sensors/' + sensor + '/' + id
                            ,   method: 'GET'
                            ,   json: true
                            }, function (err, res, body) {

                                deepEq(body.DetectionMode, NEW_DETECTION_MODE);
                                done();
                            });
                        });
                    });
                });

                it('should not overwrite detectionmode when updating position', function (done) {
                    request({
                        url: 'sensors/' + sensor
                    ,   method: 'POST'
                    ,   body: EXAMPLES[sensor].Position
                    ,   json: true
                    }, function (err, res, body) {

                        if (err) throw err;
                        var id = res.headers.location;

                        request({
                            url: 'sensors/' + sensor + '/' + id
                        ,   method: 'PUT'
                        ,   body: { DetectionMode: NEW_DETECTION_MODE }
                        ,   json: true
                        }, function (err, res, body) {

                            request({
                                url: 'sensors/' + sensor + '/' + id
                            ,   method: 'PUT'
                            ,   body: { Position: EXAMPLE_LCD.Position, DetectionMode: 3 /* the 'ignore-value' */ }
                            ,   json: true
                            }, function (err, res, body) {
                                if (err) throw err;
                                eq(res.statusCode, 200);
                                request({
                                    url: 'sensors/' + sensor + '/' + id
                                , method: 'GET'
                                , json: true
                                }, function (err, res, body) {
                                    if (err) throw err;
                                    deepEq(body.DetectionMode, NEW_DETECTION_MODE, "should not overwrite detection mode when updating position");
                                    done();
                                });
                            });
                        });
                    });
                });

            }
        });

        describe('#Delete', function() {
            it('should delete created sensor', function(done) {
                request({
                    url: 'sensors/' + sensor
                ,   method: 'POST'
                ,   body: EXAMPLES[sensor].Position
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