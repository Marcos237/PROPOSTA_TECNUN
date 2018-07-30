namespace Tecnun.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tecnun01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Data_Nascimento = c.DateTime(nullable: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Informacoes_Adicionais = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.AlunoId)
                .Index(t => t.CPF, unique: true);
            
            CreateTable(
                "dbo.AlunoTurma",
                c => new
                    {
                        AlunoTurmaId = c.Guid(nullable: false),
                        AlunoId = c.Guid(nullable: false),
                        TurmaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoTurmaId)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.TurmaId)
                .Index(t => t.AlunoId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Guid(nullable: false),
                        DataTurma = c.DateTime(nullable: false),
                        PeriodoTurma = c.String(nullable: false, maxLength: 100, unicode: false),
                        HorarioTurma = c.DateTime(nullable: false),
                        ProfessorId = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.TurmaId)
                .ForeignKey("dbo.Professor", t => t.ProfessorId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.ProfessorId)
                .Index(t => t.CPF, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turma", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.AlunoTurma", "TurmaId", "dbo.Turma");
            DropForeignKey("dbo.AlunoTurma", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.Professor", new[] { "CPF" });
            DropIndex("dbo.Turma", new[] { "ProfessorId" });
            DropIndex("dbo.AlunoTurma", new[] { "TurmaId" });
            DropIndex("dbo.AlunoTurma", new[] { "AlunoId" });
            DropIndex("dbo.Aluno", new[] { "CPF" });
            DropTable("dbo.Professor");
            DropTable("dbo.Turma");
            DropTable("dbo.AlunoTurma");
            DropTable("dbo.Aluno");
        }
    }
}
