var myApp = angular.module("AttendApp", []);

myApp.service("AttendService" , function(){
    var userList = [];
    this.list = function()
	{
		console.log(userList.length);
        return userList;
        
	}
    this.save=function(user){
        console.log(user);
		userList.push(user);
        console.log(userList.length)
    }
    
});
myApp.controller("AttendController" , function($scope , AttendService){
    console.clear();
    $scope.ActiveUsers = AttendService.list();
    $scope.Registered = false;
    $scope.MarkAttendence = function(){
        alert("Hited Method")
        $scope.uname='';
		  if($scope.name!='' ){
            AttendService.save($scope.name);
            $scope.Registered = true;
            $scope.uname=$scope.name;
			$scope.name = '';
          }
		  return;
    }; 
    
});