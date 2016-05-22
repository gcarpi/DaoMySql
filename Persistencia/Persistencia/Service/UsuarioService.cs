using Persistencia.DAO;
using Persistencia.Interface;
using Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Service
{
    public class UsuarioService
    {
        private UsuarioDAO userDAO;

        public UsuarioService()
        {
            userDAO = new UsuarioDAO();
        }
        
        public bool Inserir(string nome, string rg, string cpf, string login, string senha)
        {

            if (isNotNULL(nome, rg, cpf, login, senha))
                if (isLimitCaract(nome, 5, 50) && isLimitCaract(rg, 8, 13) && isLimitCaract(cpf, 11, 15) &&
                    isLimitCaract(login, 5, 15) && isLimitCaract(senha, 5, 15))
                    if (isAllCaract(nome) && isRG(rg) && isCPF(cpf))
                        return userDAO.Inserir(new Usuario(nome, rg, cpf, login, senha));
            return false;
        }

        public bool Atualizar(int cod_u, string nome, string rg, string cpf, string login, string senha)
        {
            if (isNotNULL(nome, rg, cpf, login, senha))
                if (isLimitCaract(nome, 5, 50) && isLimitCaract(rg, 8, 13) && isLimitCaract(cpf, 11, 15) &&
                    isLimitCaract(login, 5, 15) && isLimitCaract(senha, 5, 15))
                    if (isAllCaract(nome) && isRG(rg) && isCPF(cpf))
                        return userDAO.Atualizar(new Usuario(cod_u, nome, rg, cpf, login, senha));
            return false;
        }

        public bool Remover(int cod_user)
        {
            return userDAO.Remover(new Usuario(cod_user, 9));
        }

        public bool Inativar(int cod_user)
        {
            return userDAO.Remover(new Usuario(cod_user, 2));
        }

        public bool Ativar(int cod_user)
        {
            return userDAO.Remover(new Usuario(cod_user, 1));
        }

        public bool Autenticar(string login, string senha)
        {
            return (isLogin(login) && isSenha(senha));
        }

        public Usuario Busca(int id)
        {
            foreach (Usuario user in Listar())
                if (user.CodigoUsuario.Equals(id))
                    return user;
            return null;
        }

        public List<Usuario> Listar()
        {
            return userDAO.Listar();
        }

        public bool isAutentic(string login, string senha)
        {
            if (isNotNULL(login, senha))
                if (isLimitCaract(login, 5, 15) && isLimitCaract(senha, 5, 15))
                    if (isLogin(login) && isSenha(senha))
                        return true;
            return false;
        }

        private bool isNotNULL(params string[] lista)
        {
            foreach (string str in lista)
                if (str.Equals(""))
                    return false;
            return true;
        }

        private bool isLimitCaract(string text, int min, int max)
        {
            return (text.Length >= min) && (text.Length < max);
        }

        private bool isAllCaract(string text)
        {   
            foreach (char c in text)
            {
                int v;
                if (Int32.TryParse(c.ToString(),out v))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool isRG(string rg)
        {
            rg = rg.Trim().Replace(".", "").Replace("-", "");
            if (rg.Length != 9)
                return false;
            return true;
        }

        private bool isLogin(string login)
        {
            foreach (Usuario user in Listar())
                if (user.Login.Equals(login))
                    return true;
            return false;
        }        

        private bool isSenha(string senha)
        {
            foreach (Usuario user in Listar())
                if (user.Senha.Equals(senha))
                    return true;
            return false;
        }

    }
}