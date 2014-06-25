using Abp.Data.Migrations.FluentMigrator;
using FluentMigrator;

namespace Abp.Modules.Core.Data.Migrations.V20140323
{
    [Migration(2014032307)]
    public class _20140323_07_CreateAbpSettingsTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("AbpSettings")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("TenantId").AsInt32().Nullable().ForeignKey("AbpTenants", "Id")
                .WithColumn("UserId").AsInt32().Nullable().ForeignKey("AbpUsers", "Id")
                .WithColumn("Name").AsAnsiString(128).NotNullable()
                .WithColumn("Value").AsString().NotNullable()
                .WithAuditColumns();
        }
    }
}