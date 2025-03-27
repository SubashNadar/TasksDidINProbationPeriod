var myApp = angular.module("UserApp", []);

myApp.service("UserService" , function(){
    var userid = 0;
    var userList = [];
    this.list = function()
	{
		return userList;
	}
    this.save=function(user){
		user.id = userid++;
		userList.push(user);
    }
    this.delete = function(id)
	{
		for(var user in userList)
			{
				if(user.id == id)
				{
					userList.splice(user,1);
				}
			}
	};
    this.edit=function(id){
        for(var user in userList)
			{
				if(user.id == id)
				{
					return user.name;
				}
			}
    }
});
myApp.controller("UserController" , function($scope , UserService){
    console.clear();
    $scope.userList = UserService.list();
    $scope.Registered = false;
    $scope.vulist=false;
    $scope.vuUsers=true;
    $scope.showList = function(){
        $scope.Registered = false;
        $scope.vulist=true;
    }
    $scope.HideList = function(){
        $scope.vulist=false;
    }
    $scope.saveUser = function(){
        $scope.uname='';
        $scope.newUser.email=$scope.newUser.email+'@userapp.com';
		  if($scope.newUser.name!='' && $scope.newUser.email!='' && $scope.newUser.email!=''  && $scope.newUser.phone!='' && $scope.newUser.password!='' ){
            UserService.save($scope.newUser);
            $scope.Registered = true;
            $scope.uname=$scope.newUser.name;
			$scope.newUser = {};
          }
		  return;
    }; 
    $scope.delete = function(id){
        UserService.delete(id);
    }; 
    $scope.edit = function(id){
        var ulist=UserService.list();
        var op='';
        ulist.forEach(element => {
            if (element.id==id) {
                op=element.name;
            }
        });
        alert("Sorry User "+op+" Development in Progress");
    };
});