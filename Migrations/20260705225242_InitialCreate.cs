using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LandRegistrySystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandUses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandUses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "نام شهرستان"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "کد شهرستان"),
                    ProvinceId = table.Column<int>(type: "int", nullable: true, comment: "شناسه استان"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counties_Provinces",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "نام آبادی"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "کد آبادی"),
                    CountyId = table.Column<int>(type: "int", nullable: true, comment: "شناسه شهرستان"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villages_Counties",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersianName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FeatureClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FeatureType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ParcelCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    X = table.Column<long>(type: "bigint", nullable: true),
                    Y = table.Column<long>(type: "bigint", nullable: true),
                    Zone = table.Column<long>(type: "bigint", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UniqueParcelCode = table.Column<double>(type: "float", nullable: true),
                    ProvinceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shahrestan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AbadiName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AbadiCode = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CountyId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    NahiyeSabti = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlakName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlakAsli = table.Column<int>(type: "int", nullable: true),
                    PlakFarei = table.Column<int>(type: "int", nullable: true),
                    BakhshSabti = table.Column<int>(type: "int", nullable: true),
                    CurrentOperationLandUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CropsType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ShorakaTedad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerNationalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerMobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OwnerFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerBirthday = table.Column<DateTime>(type: "date", nullable: true),
                    OwnershipUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnershipQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnershipProof = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OperatorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OperatorLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OperatorNationalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OperatorMobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    OperatorFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OperatorBirthday = table.Column<DateTime>(type: "date", nullable: true),
                    RelationOwnerOperator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnershipConfirm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangeLandUse = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SanadMafroozi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Counties",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcels_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcels_Villages",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOperator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RelationWithOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipConfirm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOperator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelOperator_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOperator_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParcelOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    OwnershipUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipQuantity = table.Column<double>(type: "float", nullable: false),
                    OwnershipProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelOwner_Parcels_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParcelOwner_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ParcelId",
                table: "Attachments",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_County_Code",
                table: "Counties",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_County_IsDeleted",
                table: "Counties",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_County_Name",
                table: "Counties",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_County_ProvinceId",
                table: "Counties",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_County_ProvinceId_Name",
                table: "Counties",
                columns: new[] { "ProvinceId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOperator_ParcelId",
                table: "ParcelOperator",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOperator_PersonId",
                table: "ParcelOperator",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwner_ParcelId",
                table: "ParcelOwner",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelOwner_PersonId",
                table: "ParcelOwner",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerNationalCode",
                table: "Parcels",
                column: "OwnerNationalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_IsDeleted",
                table: "Parcels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelCode",
                table: "Parcels",
                column: "ParcelCode");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_CountyId",
                table: "Parcels",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ProvinceId",
                table: "Parcels",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_VillageId",
                table: "Parcels",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceName",
                table: "Parcels",
                column: "ProvinceName");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueParcelCode",
                table: "Parcels",
                column: "UniqueParcelCode");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IsDeleted",
                table: "Persons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalCode",
                table: "Persons",
                column: "NationalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Province_Code",
                table: "Provinces",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Province_IsDeleted",
                table: "Provinces",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Village_Code",
                table: "Villages",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Village_CountyId",
                table: "Villages",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Village_CountyId_Name",
                table: "Villages",
                columns: new[] { "CountyId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Village_IsDeleted",
                table: "Villages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Village_Name",
                table: "Villages",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CropTypes");

            migrationBuilder.DropTable(
                name: "LandUses");

            migrationBuilder.DropTable(
                name: "ParcelOperator");

            migrationBuilder.DropTable(
                name: "ParcelOwner");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
