$(document).ready(function () {
    $('#EmprestimosTbl').DataTable({
        language: {
            "decimal":        ",",
            "emptyTable":     "Nenhum dado disponível na tabela",
            "info":           "Mostrando _START_ até _END_ de _TOTAL_ entradas",
            "infoEmpty":      "Mostrando 0 até 0 de 0 entradas",
            "infoFiltered":   "(filtrado de um total de _MAX_ entradas)",
            "infoPostFix":    "",
            "thousands":      ".",
            "lengthMenu":     "Mostrar _MENU_ entradas",
            "loadingRecords": "Carregando...",
            "processing":     "Processando...",
            "search":         "Procurar:",
            "zeroRecords":    "Nenhum registro correspondente encontrado",
            "paginate": {
                "first":      "Primeiro",
                "last":       "Último",
                "next":       "Próximo",
                "previous":   "Anterior"
            },
            "aria": {
                "orderable":         "Ordenar por esta coluna",
                "orderableReverse":  "Ordem reversa desta coluna"
            }
        },
        pageLength: 5 
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 5000);
});
