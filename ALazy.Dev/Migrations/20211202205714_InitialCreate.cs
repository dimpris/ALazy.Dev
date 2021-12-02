using Microsoft.EntityFrameworkCore.Migrations;

namespace ALazy.Dev.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contexts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contexts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contexts_Apps_AppID",
                        column: x => x.AppID,
                        principalTable: "Apps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entities_Contexts_ContextID",
                        column: x => x.ContextID,
                        principalTable: "Contexts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arguments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MethodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BindingFlags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Methods_Entities_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Entities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BindingFlags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Properties_Entities_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Entities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contexts_AppID",
                table: "Contexts",
                column: "AppID");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_ContextID",
                table: "Entities",
                column: "ContextID");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_EntityID",
                table: "Methods",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_EntityID",
                table: "Properties",
                column: "EntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Contexts");

            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
