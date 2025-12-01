using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickFlow.BE.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_users",
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
                    table.PrimaryKey("pk_mst_users", x => x.row_id);
                });

            migrationBuilder.CreateTable(
                name: "wf_templates",
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
                    table.PrimaryKey("pk_wf_templates", x => x.row_id);
                });

            migrationBuilder.CreateTable(
                name: "wf_template_states",
                columns: table => new
                {
                    row_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    wf_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "false"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    last_modified_by = table.Column<Guid>(type: "uuid", nullable: false),
                    last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wf_template_states", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_template_states_wf_templates_wf_template_id",
                        column: x => x.wf_template_id,
                        principalTable: "wf_templates",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wf_instances",
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
                    table.PrimaryKey("pk_wf_instances", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_instances_wf_template_states_current_wf_state_id",
                        column: x => x.current_wf_state_id,
                        principalTable: "wf_template_states",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wf_instances_wf_templates_wf_template_id",
                        column: x => x.wf_template_id,
                        principalTable: "wf_templates",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wf_instance_tasks",
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
                    table.PrimaryKey("pk_wf_instance_tasks", x => x.row_id);
                    table.ForeignKey(
                        name: "fk_wf_instance_tasks_mst_users_user_id",
                        column: x => x.user_id,
                        principalTable: "mst_users",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wf_instance_tasks_wf_instances_wf_instance_id",
                        column: x => x.wf_instance_id,
                        principalTable: "wf_instances",
                        principalColumn: "row_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "mst_users",
                columns: new[] { "row_id", "created_at", "created_by", "display_name", "hashed_password", "last_modified_at", "last_modified_by", "login_name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "Administrator", null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000001"), "admin" });

            migrationBuilder.CreateIndex(
                name: "ix_mst_users_login_name",
                table: "mst_users",
                column: "login_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_tasks_user_id",
                table: "wf_instance_tasks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instance_tasks_wf_instance_id",
                table: "wf_instance_tasks",
                column: "wf_instance_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instances_current_wf_state_id",
                table: "wf_instances",
                column: "current_wf_state_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_instances_doc_id",
                table: "wf_instances",
                column: "doc_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_wf_instances_wf_template_id",
                table: "wf_instances",
                column: "wf_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_wf_template_states_wf_template_id",
                table: "wf_template_states",
                column: "wf_template_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wf_instance_tasks");

            migrationBuilder.DropTable(
                name: "mst_users");

            migrationBuilder.DropTable(
                name: "wf_instances");

            migrationBuilder.DropTable(
                name: "wf_template_states");

            migrationBuilder.DropTable(
                name: "wf_templates");
        }
    }
}
