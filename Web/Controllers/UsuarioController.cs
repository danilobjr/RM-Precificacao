using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RM.Precificacao.Web.ViewModel;
using RM.Precificacao.Infra;
using RM.Precificacao.Infra.Repositorio;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Servicos;

namespace RM.Precificacao.Web.Controllers
{
    //public class UsuarioController : Controller
    //{
    //    private MapaOfertaServicos servico;

    //    public UsuarioController()
    //    {
    //        var contexto = new RMPrecificacaoDbContext();
    //        servico = new MapaOfertaServicos(contexto);
    //    }

    //    public ActionResult Cadastro(int? id)
    //    {

    //        return View();
    //    }


    //    public ActionResult Index()
    //    {

            

    //        //using (RMPrecificacaoDbContext contexto = new RMPrecificacaoDbContext())
    //        //{
    //        //    UsuarioIndexVM lista = new UsuarioIndexVM();
    //        //    lista.Usuarios = contexto.Usuarios.ToList();

    //        //    return View(lista);
    //        //}

    //        return View();
    //    }

    //    public ActionResult Editar(int? id)
    //    {
    //        //if (id.HasValue)
    //        //{
    //        //    using (RMPrecificacaoDbContext contexto = new RMPrecificacaoDbContext())
    //        //    {
    //        //        UsuarioVM vm = new UsuarioVM();
    //        //        Usuario usuario = contexto.Usuarios.Single(u => u.Id == id);

    //        //        vm.Id = usuario.Id;
    //        //        vm.Nome = usuario.Nome;
    //        //        vm.Email = usuario.Email;
    //        //        vm.Senha = usuario.Senha;
    //        //        vm.ConfirmarSenha = usuario.Senha;
    //        //        return View(vm);
    //        //    }
    //        //}
    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult Editar(UsuarioVM vm)
    //    {
    //        using (RMPrecificacaoDbContext contexto = new RMPrecificacaoDbContext())
    //        {
    //            GerenteUsuarios gerente = new GerenteUsuarios(contexto);
    //            Usuario usuario = new Usuario();
    //            usuario.Id = vm.Id;
    //            usuario.Nome = vm.Nome;
    //            usuario.Email = vm.Email;
    //            usuario.Senha = vm.Senha;


    //            try
    //            {
    //                gerente.ValidarAlterarUsuario(usuario);

    //                contexto.Entry<Usuario>(usuario).State = System.Data.EntityState.Modified;
    //                contexto.SaveChanges();

    //                RedirectToAction("Index");
    //            }
    //            catch (RegrasDeNegocioException ex)
    //            {
    //                ex.CopiarPara(ModelState);
    //                vm.Mensagem = "Erro";                    
    //            }

    //            return View(vm);
    //        }
    //    }

    //    [HttpPost]
    //    public ActionResult Cadastro(UsuarioVM usuario)
    //    {
    //        //using (RMPrecificacaoDbContext contexto = new RMPrecificacaoDbContext())
    //        //{
    //        //    GerenteUsuarios gerenteUsuario = new GerenteUsuarios(contexto);
    //        //    try
    //        //    {
    //        //        Usuario entidadeUsuario = gerenteUsuario.CriarNovoUsuario(usuario.Nome, usuario.Senha, usuario.Email);
    //        //        contexto.Usuarios.Add(entidadeUsuario);
    //        //        contexto.SaveChanges();
    //        //        RedirectToAction("Index");
    //        //    }
    //        //    catch (RegrasDeNegocioException ex)
    //        //    {
    //        //        ex.CopiarPara(ModelState);
    //        //        usuario.Mensagem = "Erro!";
    //        //    }
    //        //}

    //        //return View(usuario);

    //        return View();
    //    }

        

    //}
}
