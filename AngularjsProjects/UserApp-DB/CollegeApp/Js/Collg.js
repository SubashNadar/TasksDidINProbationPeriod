var app = angular.module('CollgApp', []);

app.controller('CollgCtro', function ($scope, $http) {
    $scope.Registered = true;
    $scope.LoginPage = false;
    $scope.vulist=false;
    $scope.getStudents = function () {
        $http.get('https://localhost:7295/api/Student/GetStudents').success(function (data) {
            var students = data;
            
            $scope.stList = students;
            console.log($scope.stList);
            $scope.vulist=true;
        }).error(function (data) { });
    };
    $scope.addStudent = function () {
        var student =$scope.student;
        console.log(student);
        $http({
            url: 'https://localhost:7295/api/Student/AddStudent',
            method: 'POST',
            data:student
        }).success(function (data) {
            alert("Hii "+student.StudentName+" Your registration is Success !")
            $scope.students = data;
            $scope.student={}
        }).error(function (data) { });
    };
    
    
    $scope.login = function(){
        $scope.vulist=false;
        $scope.Registered = false;
        $scope.LoginPage = true;
        
    }
    $scope.verifyUser = function(){
        var name=($scope.loginName).toString().toLowerCase();
        var phoneNo=($scope.loginPhoneNo).toString().toLowerCase();
        $http.get('https://localhost:7295/api/Student/GetStudents').success(function (data) {
            var students = data;
            $scope.stList = students;
            console.log(students)
            var ifExist=false;
            students.forEach(i => {
            var lname=(i.studentName).toLowerCase();
            var lphone=(i.phoneNo).toLowerCase();
            
            if(lname==name && lphone==phoneNo){
                ifExist=true;   
            }
            
        });
        if(ifExist==true){
            alert("Login Success");
            $scope.VotePage=true;
            $scope.LoginPage=false;
        }else{
            alert("Login Failed");
        }
        }).error(function (data) { });
        
    }
    $scope.VotePage=false;
    $scope.operations = [
        { name:"Dancing", id:1 },
        { name:"Singing", id:2 },
        { name: "Playing", id:3 },
        { name:"Relaxing", id:4 }
    ];
    $scope.myFunc = function() {
        var candidateId=$scope.op=document.getElementById('sel').value;
        confirm(" Is "+candidateId+" Your Hobby ? ")
        
    };
    $scope.getResults = function () {
        $http.get('https://localhost:7295/api/Student/vuResult').success(function (data) {
            var result = data;
            
            $scope.Voteresults = result;
            console.log($scope.Voteresults);
        }).error(function (data) { });
    };
});