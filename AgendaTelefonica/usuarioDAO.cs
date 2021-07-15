using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    class usuarioDAO
    {
        int id;
        string usuario;
        string senha;

        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
    }
}
