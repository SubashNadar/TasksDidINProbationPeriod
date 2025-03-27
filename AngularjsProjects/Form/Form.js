var myApp = angular.module("RegistrationApp", []);
    myApp.controller("RegisterationController", function ($scope) {
        $scope.fname = '';
        $scope.lname = '';
        $scope.Registered = false;
        $scope.register = function(){
            $scope.fname=document.getElementById('fname').value;
            $scope.lname=document.getElementById('lname').value;
            $scope.mob=document.getElementById('mob').value;
            $scope.email=document.getElementById('email').value;
            $scope.pass=document.getElementById('pass').value;
            if($scope.fname!='' && $scope.lname!='' && $scope.mob!='' && $scope.email!='' && $scope.pass!=''){
                $scope.Registered = true;
                
            }
            
        }
    });

