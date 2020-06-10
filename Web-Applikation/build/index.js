"use strict";
var baseUri = "https://localhost:44367/api/transporttabs";
new Vue({
    el: "#app",
    data: {
        transporttabs: [],
        errors: [],
        deleteId: 0,
        deleteMessage: "",
        formData: { lastbil: "", chauffor: "", dato: "", antalKm: 0, gennemsnit: 0 },
        addMessage: ""
    },
    methods: {
        getAllCars: function () {
            var _this = this;
            axios.get(baseUri)
                .then(function (response) {
                _this.transporttabs = response.data;
            })
                .catch(function (error) {
                //this.message = error.message
                alert(error.message); // https://www.w3schools.com/js/js_popup.asp
            });
        },
        deleteCar: function (deleteId) {
            var _this = this;
            var uri = baseUri + "/" + deleteId;
            axios.delete(uri)
                .then(function (response) {
                _this.deleteMessage = response.status + " " + response.statusText;
                _this.getAllCars();
            })
                .catch(function (error) {
                //this.deleteMessage = error.message
                alert(error.message);
            });
        },
        addCar: function () {
            var _this = this;
            axios.post(baseUri, this.formData)
                .then(function (response) {
                var message = "response " + response.status + " " + response.statusText;
                _this.addMessage = message;
                _this.getAllCars();
            })
                .catch(function (error) {
                // this.addMessage = error.message
                alert(error.message);
            });
        }
    }
});
