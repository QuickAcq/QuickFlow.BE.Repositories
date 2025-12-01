using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickFlow.BE.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_user",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    login_name = table.Column<string>(type: "text", nullable: false),
                    hashed_password = table.Column<string>(type: "text", nullable: true),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_user", x => x.row_id);
                });

            migrationBuilder.CreateTable(
                name: "mst_wf_state_type",
                columns: table => new
                {
                    row_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mst_wf_state_type", x => x.row_id);
                });

            migrationBuilder.CreateTable(
                name: "wf_template",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wf_template", x => x.row_id);
                });

            migrationBuilder.CreateTable(
                name: "wf_template_state",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    wf_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mst_wf_state_type_id = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wf_template_state", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_template_state_mst_wf_state_type_mst_wf_state_type_id",
                        column: x => x.mst_wf_state_type_id,
                        principalTable: "mst_wf_state_type",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wf_template_state_wf_template_wf_template_id",
                        column: x => x.wf_template_id,
                        principalTable: "wf_template",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wf_instance",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    wf_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    doc_id = table.Column<string>(type: "text", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    current_wf_state_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wf_instance", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_instance_wf_template_state_current_wf_state_id",
                        column: x => x.current_wf_state_id,
                        principalTable: "wf_template_state",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wf_instance_wf_template_wf_template_id",
                        column: x => x.wf_template_id,
                        principalTable: "wf_template",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wf_instance_task",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    wf_instance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_valid = table.Column<bool>(type: "boolean", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wf_instance_task", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_instance_task_mst_user_user_id",
                        column: x => x.user_id,
                        principalTable: "mst_user",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wf_instance_task_wf_instance_wf_instance_id",
                        column: x => x.wf_instance_id,
                        principalTable: "wf_instance",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "mst_user",
                columns: new[] { "row_id", "created_at", "created_by", "display_name", "hashed_password", "last_modified_at", "last_modified_by", "login_name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "Administrator", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "admin" });

            migrationBuilder.InsertData(
                table: "mst_wf_state_type",
                columns: new[] { "row_id", "name" },
                values: new object[,]
                {
                    { 1, "Start" },
                    { 2, "End" },
                    { 3, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "wf_template",
                columns: new[] { "row_id", "created_at", "created_by", "last_modified_at", "last_modified_by", "name", "version" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "DummyTemplate", 1 });

            migrationBuilder.InsertData(
                table: "wf_template_state",
                columns: new[] { "row_id", "created_at", "created_by", "last_modified_at", "last_modified_by", "mst_wf_state_type_id", "wf_template_id" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), 1, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.CreateIndex(
                name: "ix_mst_user_login_name",
                table: "mst_user",
                column: "login_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_current_wf_state_id",
                table: "wf_instance",
                column: "current_wf_state_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_doc_id",
                table: "wf_instance",
                column: "doc_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_wf_template_id",
                table: "wf_instance",
                column: "wf_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_task_user_id",
                table: "wf_instance_task",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_task_wf_instance_id",
                table: "wf_instance_task",
                column: "wf_instance_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_template_state_mst_wf_state_type_id",
                table: "wf_template_state",
                column: "mst_wf_state_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_template_state_wf_template_id",
                table: "wf_template_state",
                column: "wf_template_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wf_instance_task");

            migrationBuilder.DropTable(
                name: "mst_user");

            migrationBuilder.DropTable(
                name: "wf_instance");

            migrationBuilder.DropTable(
                name: "wf_template_state");

            migrationBuilder.DropTable(
                name: "mst_wf_state_type");

            migrationBuilder.DropTable(
                name: "wf_template");
        }
    }
}
