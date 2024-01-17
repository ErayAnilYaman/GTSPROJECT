using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHORS",
                columns: table => new
                {
                    AUTHORID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AUTHORNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORS", x => x.AUTHORID);
                });

            migrationBuilder.CreateTable(
                name: "INSTITUTES",
                columns: table => new
                {
                    INSTITUTEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTITUTES", x => x.INSTITUTEID);
                });

            migrationBuilder.CreateTable(
                name: "KEYWORDS",
                columns: table => new
                {
                    KEYWORDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KEYWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KEYWORDS", x => x.KEYWORDID);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECTTOPICS",
                columns: table => new
                {
                    TOPICID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOPICNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECTTOPICS", x => x.TOPICID);
                });

            migrationBuilder.CreateTable(
                name: "SUPERVISORS",
                columns: table => new
                {
                    SUPERVISORID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPERVISORS", x => x.SUPERVISORID);
                });

            migrationBuilder.CreateTable(
                name: "UNIVERSITIES",
                columns: table => new
                {
                    UNIVERSITYID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIVERSITIES", x => x.UNIVERSITYID);
                });

            migrationBuilder.CreateTable(
                name: "THESES",
                columns: table => new
                {
                    THESISID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMBER = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ABSTRACT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AUTHORID = table.Column<int>(type: "int", nullable: false),
                    THESISYEAR = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    INSTITUTEID = table.Column<int>(type: "int", nullable: false),
                    SUPERVISORID = table.Column<int>(type: "int", nullable: false),
                    UNIVERSITYID = table.Column<int>(type: "int", nullable: false),
                    PAGES = table.Column<int>(type: "int", nullable: false),
                    LANGUAGE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SUBMISSIONDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THESES", x => x.THESISID);
                    table.ForeignKey(
                        name: "FK_THESES_AUTHORS_AUTHORID",
                        column: x => x.AUTHORID,
                        principalTable: "AUTHORS",
                        principalColumn: "AUTHORID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THESES_INSTITUTES_INSTITUTEID",
                        column: x => x.INSTITUTEID,
                        principalTable: "INSTITUTES",
                        principalColumn: "INSTITUTEID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THESES_SUPERVISORS_SUPERVISORID",
                        column: x => x.SUPERVISORID,
                        principalTable: "SUPERVISORS",
                        principalColumn: "SUPERVISORID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THESES_UNIVERSITIES_UNIVERSITYID",
                        column: x => x.UNIVERSITYID,
                        principalTable: "UNIVERSITIES",
                        principalColumn: "UNIVERSITYID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COSUPERVISORTHESIS",
                columns: table => new
                {
                    COSUPERVISORTHESISID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THESISID = table.Column<int>(type: "int", nullable: false),
                    SUPERVISORID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COSUPERVISORTHESIS", x => x.COSUPERVISORTHESISID);
                    table.ForeignKey(
                        name: "FK_COSUPERVISORTHESIS_SUPERVISORS_SUPERVISORID",
                        column: x => x.SUPERVISORID,
                        principalTable: "SUPERVISORS",
                        principalColumn: "SUPERVISORID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COSUPERVISORTHESIS_THESES_THESISID",
                        column: x => x.THESISID,
                        principalTable: "THESES",
                        principalColumn: "THESISID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "THESISKEYWORD",
                columns: table => new
                {
                    THESISKEYWORDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THESISID = table.Column<int>(type: "int", nullable: false),
                    KEYWORDID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THESISKEYWORD", x => x.THESISKEYWORDID);
                    table.ForeignKey(
                        name: "FK_THESISKEYWORD_KEYWORDS_KEYWORDID",
                        column: x => x.KEYWORDID,
                        principalTable: "KEYWORDS",
                        principalColumn: "KEYWORDID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THESISKEYWORD_THESES_THESISID",
                        column: x => x.THESISID,
                        principalTable: "THESES",
                        principalColumn: "THESISID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "THESISSUBJECTTOPIC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    THESISID = table.Column<int>(type: "int", nullable: false),
                    TOPICID = table.Column<int>(type: "int", nullable: false),
                    SUBJECTTOPICTOPICID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THESISSUBJECTTOPIC", x => x.ID);
                    table.ForeignKey(
                        name: "FK_THESISSUBJECTTOPIC_SUBJECTTOPICS_SUBJECTTOPICTOPICID",
                        column: x => x.SUBJECTTOPICTOPICID,
                        principalTable: "SUBJECTTOPICS",
                        principalColumn: "TOPICID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THESISSUBJECTTOPIC_THESES_THESISID",
                        column: x => x.THESISID,
                        principalTable: "THESES",
                        principalColumn: "THESISID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COSUPERVISORTHESIS_SUPERVISORID",
                table: "COSUPERVISORTHESIS",
                column: "SUPERVISORID");

            migrationBuilder.CreateIndex(
                name: "IX_COSUPERVISORTHESIS_THESISID",
                table: "COSUPERVISORTHESIS",
                column: "THESISID");

            migrationBuilder.CreateIndex(
                name: "IX_THESES_AUTHORID",
                table: "THESES",
                column: "AUTHORID");

            migrationBuilder.CreateIndex(
                name: "IX_THESES_INSTITUTEID",
                table: "THESES",
                column: "INSTITUTEID");

            migrationBuilder.CreateIndex(
                name: "IX_THESES_SUPERVISORID",
                table: "THESES",
                column: "SUPERVISORID");

            migrationBuilder.CreateIndex(
                name: "IX_THESES_UNIVERSITYID",
                table: "THESES",
                column: "UNIVERSITYID");

            migrationBuilder.CreateIndex(
                name: "IX_THESISKEYWORD_KEYWORDID",
                table: "THESISKEYWORD",
                column: "KEYWORDID");

            migrationBuilder.CreateIndex(
                name: "IX_THESISKEYWORD_THESISID",
                table: "THESISKEYWORD",
                column: "THESISID");

            migrationBuilder.CreateIndex(
                name: "IX_THESISSUBJECTTOPIC_SUBJECTTOPICTOPICID",
                table: "THESISSUBJECTTOPIC",
                column: "SUBJECTTOPICTOPICID");

            migrationBuilder.CreateIndex(
                name: "IX_THESISSUBJECTTOPIC_THESISID",
                table: "THESISSUBJECTTOPIC",
                column: "THESISID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COSUPERVISORTHESIS");

            migrationBuilder.DropTable(
                name: "THESISKEYWORD");

            migrationBuilder.DropTable(
                name: "THESISSUBJECTTOPIC");

            migrationBuilder.DropTable(
                name: "KEYWORDS");

            migrationBuilder.DropTable(
                name: "SUBJECTTOPICS");

            migrationBuilder.DropTable(
                name: "THESES");

            migrationBuilder.DropTable(
                name: "AUTHORS");

            migrationBuilder.DropTable(
                name: "INSTITUTES");

            migrationBuilder.DropTable(
                name: "SUPERVISORS");

            migrationBuilder.DropTable(
                name: "UNIVERSITIES");
        }
    }
}
