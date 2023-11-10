var express = require('express');
var app = express();
  
var cpt = 0;
var anim = "idle";

app.get('/', function (req, res) {
    res.send('Hello World <form action="/dance" method="post"><input type="submit" value="Dance"></form> <form action="/idle" method="post"><input type="submit" value="Idle"></form>');
});
// app.post('/', function (req, res) {
//     res.send('base <form action="/dance" method="post"><input type="submit" value="Dance"></form> <form action="/idle" method="post"><input type="submit" value="Idle"></form>');
// });

app.post('/dance', function (req, res) {
    // cpt = cpt + 1;
    // console.log(cpt);
    anim = "dance";
    res.send('Dance <form action="/idle" method="post"><input type="submit" value="Idle"></form>');
});

app.post('/idle', function (req, res) {
    // cpt = cpt + 1;
    // console.log(cpt);
    anim = "idle";
    res.send('Idle <form action="/dance" method="post"><input type="submit" value="Dance"></form>');
});

app.post('/test', function (req, res) {
    // cpt = cpt + 1;
    // console.log(cpt);
    // console.log(req);
    res.send(anim);
});

app.get('/test', function (req, res) {
    // cpt = cpt + 1;
    // console.log(cpt);
    // console.log(req);
    res.send(anim);
});

var server = app.listen(5000, function () {
    console.log('Node server is running..');
});
