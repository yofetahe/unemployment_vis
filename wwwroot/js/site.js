// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DisplayGraph(listValue){
    
    var info = listValue.split("|");
    
    var dataArray = [];

    for(var i = 0, j = 0; i < info.length-1; i += 2, j++){
        var graphInput = {}
        graphInput["name"] = info[i];
        var num = info[i+1].split(",");        
        var data = [];
        for(var j = 0; j < num.length-1; j++){
            data[j] = Number(num[j]);
        }
        graphInput["data"] = data;
        dataArray.push(graphInput);
    }

    Highcharts.chart('container', {

        title: {
          text: 'Unemployment Rate, 2009-2018'
        },
      
        subtitle: {
          text: 'Source: governementOffice.com'
        },
      
        yAxis: {
          title: {
            text: 'Unemployment Rate'
          }
        },
        legend: {
          layout: 'vertical',
          align: 'right',
          verticalAlign: 'middle'
        },
      
        plotOptions: {
          series: {
            label: {
              connectorAllowed: false
            },
            pointStart: 2009
          }
        },
      
        series: dataArray,
      
        responsive: {
          rules: [{
            condition: {
              maxWidth: 500
            },
            chartOptions: {
              legend: {
                layout: 'horizontal',
                align: 'center',
                verticalAlign: 'bottom'
              }
            }
          }]
        }      
    });
}

function DisplayMap(listValue){
    
    var info = listValue.split("|");
    console.log(info);
    var dataArray = [];

    for(var i = 0, j = 0; i < info.length-1; i += 2, j++){
        var graphInput = {}        
        graphInput["value"] = Number(parseFloat(info[i+1]).toFixed(2));
        graphInput["code"] = info[i];
        dataArray.push(graphInput);
    }
    console.log(dataArray);

    Highcharts.mapChart('container', {

        chart: {
          map: 'countries/us/us-all',
          borderWidth: 1
        },
    
        title: {
          text: 'Unemployment Rate per State (%)'
        },
    
        exporting: {
          sourceWidth: 600,
          sourceHeight: 500
        },
    
        legend: {
          layout: 'horizontal',
          borderWidth: 0,
          backgroundColor: 'rgba(255,255,255,0.85)',
          floating: true,
          verticalAlign: 'top',
          y: 25
        },
    
        mapNavigation: {
          enabled: true
        },
    
        colorAxis: {
          min: 1,
          type: 'logarithmic',
          minColor: '#EEEEFF',
          maxColor: '#000022',
          stops: [
            [0, '#EFEFFF'],
            [0.67, '#4444FF'],
            [1, '#000022']
          ]
        },
    
        series: [{
          animation: {
            duration: 1000
          },
          data: dataArray,
          joinBy: ['postal-code', 'code'],
          dataLabels: {
            enabled: true,
            color: '#FFFFFF',
            format: '{point.code}'
          },
          name: 'Unemployment Rate',
          tooltip: {
            pointFormat: '{point.code}: {point.value}%'
          }
        }]
      });    
}

