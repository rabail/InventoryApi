var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

router.get('/inventory', function(req, res, next) { 
  res.send({
      startDate: "10-03-2015",
      endDate: "11-19-2015"
      // allowedArrivalDays: {
      //     M: true,
      //     Tu: true,
      //     W: false,
      //     Th: false,
      //     F: true,
      //     Sa: false,
      //     Su: true,
      // },
      // allowedDepartureDays: {
      //     M: true,
      //     Tu: true,
      //     W: false,
      //     Th: false,
      //     F: true,
      //     Sa: true,
      //     Su: true,
      // }
  });
});
module.exports = router;
