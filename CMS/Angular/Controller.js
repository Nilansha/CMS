app.controller("courseController", function ($scope,$window, myService) {

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

    //Edit course by id
    $scope.editCourse = function () {
        var hash = window.location.hash; //#2
        var id = hash.replace('#', ''); //2

        var getData = myService.getCourseById(parseInt(id));
        getData.then(function (courseData) {
            $scope.Course = courseData.data;
            $scope.Course_Id = courseData.data.Course_Id;
            $scope.Course_Name = courseData.data.Course_Name;
            $scope.Course_Status = courseData.data.Course_Status;
            $scope.Action = "Update";
        },
        function () {
            alert('Error in getting records');
        });
    };

    //Add or Update a course
    $scope.AddOrUpdateCourses = function () {
        if ($scope.Course_Name == '' || $scope.Course_Status == '') {
            alert('Input Field is required');
            return false;
        }
        var Courses = {
            Course_Name: $scope.Course_Name,
            Course_Status: $scope.Course_Status,
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            //alert('Update')
            Courses.Course_Id = $scope.Course_Id;
            var getData = myService.updateCourse(Courses);
            getData.then(function (msg) {
                $window.location.href ="/Courses";
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getData = myService.addCourse(Courses);
            getData.then(function (msg) {
                $window.location.href ="/Courses";
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    //Delete a course
    $scope.deleteCourse = function () {
        debugger;
        var hash = window.location.hash; //#2
        var id = hash.replace('#', ''); //2

        var getData = myService.deleteCourse(id);
        debugger;
        getData.then(function (msg) {
            $window.location.href = "/Courses";
            alert('Employee Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    
});