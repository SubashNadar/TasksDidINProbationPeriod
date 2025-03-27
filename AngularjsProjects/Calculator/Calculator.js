var calculation = angular.module('calculation', [])
.controller('calc', function ($scope) {
    $scope.operations = [
        { operation:"Addition", value:1 },
        { operation:"Subtraction", value:2 },
        { operation: "Multiplication", value:3 },
        { operation:"Division", value:4 }
    ];
    $scope.add=false;
    $scope.sub=false;
    $scope.mul=false;
    $scope.div=false;
    $scope.value1=null;
    $scope.value2=null;
    $scope.added=null;
    $scope.subtracted=null;
    $scope.multiplied=null;
    $scope.divided=null;
    $scope.op=null;
    $scope.myFunc = function() {
        $scope.op=document.getElementById('sel').value;
        if($scope.op==1){
            $scope.value1=$scope.value1 + $scope.value2;
            $scope.added=$scope.value1 ;
            $scope.value2=null;
            $scope.sub=false;
            $scope.mul=false;
            $scope.div=false;
            $scope.add=true;
            $scope.choosed=null;
            

        }else if($scope.op==2){
            $scope.add=false;
            $scope.mul=false;
            $scope.div=false;
            $scope.sub=true;
            $scope.value1=$scope.value1 - $scope.value2;
            $scope.subtracted=$scope.value1 ;
            $scope.value2=null;
            $scope.choosed=null;
            

        }else if($scope.op==3){
            $scope.add=false;
            $scope.sub=false;
            $scope.div=false;
            $scope.mul=true;
            $scope.value1=$scope.value1 * $scope.value2;
            $scope.multiplied=$scope.value1 ;
            $scope.value2=null;
            $scope.choosed=null;
            
            
        }else if($scope.op==4){
            $scope.div=true;
            $scope.add=false;
            $scope.sub=false;
            $scope.mul=false;
            $scope.value1=$scope.value1 / $scope.value2;
            $scope.divided=$scope.value1 ;
            $scope.value2=null;
            $scope.choosed=null;
            
            
        }else{
            $scope.div=false;
            $scope.add=false;
            $scope.sub=false;
            $scope.mul=false; 
        }

    };
    
});

