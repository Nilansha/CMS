﻿app.service("myService", function ($http) {

     //Service :: Get all courses
     this.getAllCourses = function () {
         return $http.get("/Courses/GetAllCourses")
     };

     //Service :: Get couse by id
     this.getCourseById = function (courseId) {
         var response = $http({
             method: "post",
             url: "/Courses/GetDetailsById",
             params: {
                 id: JSON.stringify(courseId)
             }
         });
         return response;
     };


         
})