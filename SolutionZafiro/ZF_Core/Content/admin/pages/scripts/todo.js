/**
Todo Module
**/
var Todo = function () {

    // private functions & variables

    var _initComponents = function() {
        
        // init datepicker
        $('.todo-taskbody-due').datepicker({
            rtl: Backbones.isRTL(),
            orientation: "left",
            autoclose: true
        });

        // init tags        
        $(".todo-taskbody-tags").select2({
            tags: ["Testing", "Important", "Info", "Pending", "Completed", "Requested", "Approved"]
        });
    }

    var _handleProjectListMenu = function() {
        if (Backbones.getViewPort().width <= 992) {
            $('.todo-project-list-content').addClass("collapse");
        } else {
            $('.todo-project-list-content').removeClass("collapse").css("height", "auto");
        }
    }

    // public functions
    return {

        //main function
        init: function () {
            _initComponents();     
            _handleProjectListMenu();

            Backbones.addResizeHandler(function(){
                _handleProjectListMenu();    
            });       
        }

    };

}();