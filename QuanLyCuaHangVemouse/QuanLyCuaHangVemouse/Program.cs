using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataModel;
using BusinessLogicLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IKhachHang, DAL_KhachHang>();
builder.Services.AddTransient<IKhachHang_BLL, BLL_KhachHang>();
builder.Services.AddTransient<INhaCungCap, DAL_NhaCungCap>();
builder.Services.AddTransient<INhaCungCap_BLL, BLL_NhaCungCap>();
builder.Services.AddTransient<ITheLoai, DAL_TheLoai>();
builder.Services.AddTransient<ITheLoai_BLL, BLL_TheLoai>();
builder.Services.AddTransient<ISanPham, DAL_SanPham>();
builder.Services.AddTransient<ISanPham_BLL, BLL_SanPham>();
builder.Services.AddTransient<ILoaiTaiKhoan, DAL_LoaiTaiKhoan>();
builder.Services.AddTransient<ILoaiTaiKhoan_BLL, BLL_LoaiTaiKhoan>();
builder.Services.AddTransient<ITaiKhoan, DAL_TaiKhoan>();
builder.Services.AddTransient<ITaiKhoan_BLL, BLL_TaiKhoan>();
builder.Services.AddTransient<IHoaDonBan, DAL_HoaDonBan>();
builder.Services.AddTransient<IHoaDonBan_BLL, BLL_HoaDonBan>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
