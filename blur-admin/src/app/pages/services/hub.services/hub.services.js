// (function () {
//     'use strict';
//     angular.module('BlurAdmin.pages')
//         .factory('backendHubProxy', backendHubProxy);
//     /** @ngInject */
//     function backendHubProxy($scope, backendServerUrl) {
//         console.log('trying to connect to service')
//         var performanceDataHub = backendHubProxy(backendHubProxy.defaultServer, 'myHub');
//         console.log('connected to service')
//         $scope.currentRamNumber = 68;
//         console.log(performanceDataHub);
//         performanceDataHub.on('broadcastPerformance', function (data) {
//             console.log(data);
//           data.forEach(function (dataItem) {
//             switch(dataItem.categoryName) {
//               case 'Processor':
//                 break;
//               case 'Memory':
//                 $scope.currentRamNumber = dataItem.value;
//                 break;
//               case 'Network In':
//                 break;
//               case 'Network Out':
//                 break;
//               case 'Disk Read Bytes/Sec':
//                 break;
//               case 'Disk Write Bytes/Sec':
//                 break;
//               default:
//                 //default code block
//                 break;           
//             }
//           });     
//         });
//       }
// })();