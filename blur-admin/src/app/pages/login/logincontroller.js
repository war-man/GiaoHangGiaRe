(function() {
    'use strict';
  
    angular.module('BlurAdmin.pages.login')
      .controller('logincontroller', logincontroller);
  
    /** @ngInject */
    function logincontroller($scope,$rootScope, localStorage, $state,GetUserAPI) {
      
      var vm = this;
      //$rootScope.token='';
      vm.logar = logar;
      
      init();
  
      function init() {
        //localStorage.clear();
      }
  
      function logar() {

        var dadosUser = {
          user: vm.user,
          passWord: vm.passWord
        };
        var input='grant_type=password&username='+vm.user+'&password='+vm.passWord;

         GetUserAPI.user_login(input)

        .success(function (data, status) {

          $rootScope.token=data; // luu token vao rootScope
          
          localStorage.setObject('token', data); // luu token vao trinh duyet

          localStorage.setObject('dataUser', dadosUser);// luu tai khoan, mat khau vao trinh duyet

          //console.log('luu token' + data);

          $state.go('dashboard');

        })

        .error(function (data, status) {
          alert('that bai'+ data+ status);
        });;


        
        // localStorage.setObject('dataUser', dadosUser);
        // $state.go('dashboard');
      }
      
      function logout(){
        localStorage.clear();
        $state.go('login');
      }
  
    }
  
  })();