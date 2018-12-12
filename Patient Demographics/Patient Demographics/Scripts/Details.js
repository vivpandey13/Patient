var app = angular.module('myApp', []);
app.controller('myCtrl', ['$scope', '$http', function ($scope,$http) {
    var baseUrl = 'http://localhost:63971/api/';
    $scope.patientDetailsModel = this;
    $scope.patientDetailsModel.phoneTypes = ['Home', 'Work', 'Mobile'];
    $scope.patientDetailsModel.ContactInfoData = {};
    $scope.patientDetailsModel.ContactInfoData.Contact = {};
    $scope.patientDetailsModel.ContactInfoData.Contact.Phones = [];
    $scope.patientDetailsModel.ForeName = "";
    $scope.patientDetailsModel.SurName = "";
    $scope.patientDetailsModel.Gender = "";
    $scope.patientDetailsModel.DOB = "";
    $scope.patientDetailsModel.gender = ['Male','Female','X'];
    $scope.patientDetailsModel.addPhone = function (contactType, cnumber) {
        var ph = { ContactType: contactType, ContactNumber: cnumber };

        if (!$scope.patientDetailsModel.ContactInfoData.Contact.Phones) {
            $scope.patientDetailsModel.ContactInfoData.Contact.Phones = [];
        }
        $scope.patientDetailsModel.ContactInfoData.Contact.Phones.push(ph);

    };
    var successCallback = function () {
        window.location.href = "http://localhost:63971/Patient";
    };
    var errorCallback = function () {
        window.location.href = "http://localhost:63971/Error/Index";
    };
    $scope.patientDetailsModel.savePatient  = function () {
        var patient = {
            ForeName: $scope.patientDetailsModel.ForeName,
            SurName: $scope.patientDetailsModel.SurName,
            DateOfBirth: $scope.patientDetailsModel.DOB,
            Gender : $scope.patientDetailsModel.gender,
            Contacts: $scope.patientDetailsModel.ContactInfoData.Contact.Phones
        };
        var apiRoute = baseUrl + 'Values/';
        $http({
            method: 'POST',
            url: apiRoute,
            data: patient
        }).then(successCallback, errorCallback);


    };
}]);