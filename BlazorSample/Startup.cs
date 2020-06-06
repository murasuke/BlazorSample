using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiniBlazorApp1
{
    //
    public class Startup
    {
        // ランタイムから呼び出されるメソッド(Configureより先)
        // Webアプリに必要な機能をここで追加する
        public void ConfigureServices(IServiceCollection services)
        {
            // ServerSideBlazorを利用するため、RazorPagesとServerSideBlazorを追加
            services.AddRazorPages();       //Blazor
            services.AddServerSideBlazor(); //Blazor
        }

        // ランタイムから呼び出される(ConfigureServicesの後)
        // HTTPリクエストパイプラインを設定する
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // 開発中の場合、開発者例外ページを有効にする
                app.UseDeveloperExceptionPage();
            }

            // ルーティングを標準設定で構成する
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // 対話型コンポーネントの着信接続を受け入れる（よくわからない）
                endpoints.MapBlazorHub(); //Blazor

                // フォールバックページ(他に該当がない場合に表示する)
                endpoints.MapFallbackToPage("/index"); //Blazor
            });
        }
    }
}
