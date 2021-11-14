function AjaxModal() {
    $(document).ready(function() {
        $(function() {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function(e) {
                    $('#myModalContent').load(this.href,
                        function() {
                            $('#myModal').modal({
                                    keyboard: true
                                },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function() {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    sucess: function(result) {
                        if (result.sucess) {
                            $('#myModal').modal('hide');
                            $('#TarefaTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });

        }
    });
}


function closeModal() {
    $('#modalEdit').modal('hide'); 
    //$('#modalDelete').modal('hide'); 

    window.location.href = "/Tarefas/Index";
    window.location.href = "/Tarefas/TarefasFeitas";

}