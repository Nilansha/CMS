app.controller("courseController", function ($scope, myService) {

    //Get all courses 
    $scope.GetAllCourses = function () {
        var getData = myService.getAllCourses();
        getData.then(function (res) {
            $scope.courses = res.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    //Show course details
    $scope.getCourseById = function () {
        var hash = window.location.hash; //#2
        var id = hash.replace('#', ''); //2
        var getData = myService.getCourseById(parseInt(id));
        getData.then(function (res) {
            if (res.data != null || res.data != '') {
                $scope.course = res.data;
            } else {
                alert('No data available');
            }
        }, function () {
            alert('Error in getting records');
        });
    };

    
});