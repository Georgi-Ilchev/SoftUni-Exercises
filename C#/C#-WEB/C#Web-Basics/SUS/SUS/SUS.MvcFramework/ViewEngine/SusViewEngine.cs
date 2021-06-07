using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace SUS.MvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(templateCode);
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
            string html = executableObject.ExecuteTemplate(viewModel);

            return html;
        }
        private string GenerateCSharpFromTemplate(string templateCode)
        {
            string methodBody = GetMethodBody(templateCode);
            string csharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collection.Generic;
using SUS.MvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();

            " + methodBody + @"

            return html.ToString();
        }
    }
}
";

            return csharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            return string.Empty;
        }

        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            var compileResult = CSharpCompilation
                .Create("ViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

            if (viewModel != null)
            {
                compileResult = compileResult.AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            var libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();

            foreach (var library in libraries)
            {
                compileResult = compileResult.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));
            compileResult.Emit("view.dll");

            return null;
        }
    }
}
