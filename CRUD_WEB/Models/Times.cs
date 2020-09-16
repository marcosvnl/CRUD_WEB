using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CRUD_WEB.Models
{
    public class Times
    {
        /*
         ANOTAÇÕES:
            - Digite prop e Tab 2x para preenchimeto automático da propiedade.
            - Comando [Required(ErrorMessage = "Mensagem para o usuario")] para validação do cadastro.
            - Para o comando a Required funcionar é nescessario chamar a biblioteca using System.ComponentModel.DataAnnotations;
            -   
         */
        [Required(ErrorMessage = "Informe o ID do time")]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do time")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o Estado do time")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as Cores do time")]
        public string Cores { get; set; }
    }
}