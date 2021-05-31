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

     //Service :: Update course
     this.updateCourse = function (course) {
         var response = $http({
             method: "post",
             url: "/Courses/UpdateCourse",
             data: JSON.stringify(course),
             dataType: "json"
         });
         return response;
     };

     //Service :: Add course
     this.addCourse = function (course) {
         debugger;
         var response = $http({
             method: "post",
             url: "/Courses/CreateCourse",
             data: JSON.stringify(course),
             dataType: "json"
         });
         return response;
     };

     //Service :: Delete course
     this.deleteCourse = function (courseId) {
         var intId = parseInt(courseId);
         var response = $http({
             method: "post",
             url: "/Courses/DeleteById",
             params: {
                 id: JSON.stringify(intId)
             }
         });
         return response;
     };
         
})