var PST=angular.module("PagingSort",[]);
PST.controller("PagingSortCtro",function($scope){
    var users=[
        {id:1,name:'Subash',email:'Sub@gmail.com',location:'Mumbai'},
        {id:2,name:'Som',email:'Sam@gmail.com',location:'Mumbai'   },
        {id:3,name:'Dam',email:'Sai@gmail.com',location:'Chennai'  },
        {id:4,name:'Ram',email:'Adi@gmail.com',location:'Ooty'     },
        {id:5,name:'Aam',email:'Raj@gmail.com',location:'Mumbai'   },
        {id:6,name:'Bom',email:'Daaralu@gmail.com',location:'Kovai'},
        {id:7,name:'Candy',email:'Nish@gmail.com',location:'Pune'  },
        {id:8,name:'NAndy',email:'Ramya@gmail.com',location:'Madurai'},
        {id:9,name:'Gopika',email:'Gopi@gmail.com',location:'Mumbai'},
        {id:10,name:'Karthika',email:'Kart@gmail.com',location:'Nioda'},
        {id:11,name:'Kavya',email:'Randam@gmail.com',location:'Mumbai'},
        {id:12,name:'ARm',email:'Xyx@gmail.com',location:'Rajastan'},
        {id:13,name:'Ramya',email:'Xzzx@gmail.com',location:'Delhi'},
        {id:14,name:'Nisha',email:'Dfs@gmail.com',location:'Kerla'},
        {id:15,name:'Pachakili',email:'ABC@gmail.com',location:'Munar'},
        
    ];
    $scope.userData=users;
    console.log($scope.userData)
    
    $scope.search=function(){
        var searched=[];
        alert($scope.val);
        users.forEach(i => {
            var typed=($scope.val).toString().toLowerCase();
            var usrname=(i.name).toLowerCase();
            console.log(typed+"----"+usrname)
            if(usrname.startsWith(typed)){
                
                searched.push(i);
            }
            
        });
        $scope.userData='';
        $scope.userData=searched;

    }
    

});