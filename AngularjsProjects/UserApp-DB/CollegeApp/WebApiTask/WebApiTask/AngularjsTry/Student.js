var app;
(function () {
    app = angular.module('myapp', []);
})();

app.service('StudentService', function ($http) { 
    var getUrl = '';
    this.getAllstudents = function (apiRoute) {
        getUrl = apiRoute;
        return $http.get(getUrl);
    }
});
app.controller('StudentCtrl', ['$scope', 'StudentService',function ($scope, StudentService) {
        var baseUrl = '/api/student/';
       $scope.getStudents = function () {
           var apiRoute = baseUrl + 'GetStudents';
            var stud = StudentService.getAll(apiRoute);
            stud.then(function (response) {
                $scope.students = response.data;
            },
                function (error) {
                    console.log("Error: " + error);
                });

        }
        $scope.getStudents();

    }]);