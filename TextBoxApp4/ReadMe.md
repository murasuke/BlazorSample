# Userマスタメンテナンス

## 環境、ライブラリ
- .Net Core3.1
  - Blazorは.NET Frameworkで動かないため.Net Core3.0以降が必須
- Blazor Server
  - C#でWebクライアントUI を実装するためのフレームワーク
- EntityFramework
  - ORマッパー(DBライブラリ)
- SQLServer LocalDB
  - プロジェクト内に専用DBデータ(.mdb)を持つことができるプロジェクト用SQLserver
  - ACCESSのmdbファイルのようなイメージで使うことができる

クライアント
- Bootstrap
  - レスポンシブ対応、デザインの統一性確保のため
- JQuery
  - Bootstrapで必要(ダイアログ表示など)



## 仕様


## なぜこの構成で作ったか
- Blazorの理解
  - CRUD
  - ダイアログ表示(検索画面など)
  - JavaScriptとの相互呼び出し
- SQLserver LocalDBの利用
  - DBをプロジェクト毎(個人のローカルPCのDB)に配布することができる。
    - ユニットテストがやりやすくなる(個人専用。mdbファイルを元にもどせばデータが消える)
  - DBファイル自体ソース管理システムで管理できるのではないか？
- Bootstrapを利用して、レスポンシブ対応サイトの作り方を理解する
- EntityFramework
  - ADO.NET自体はメンテナンスモードで今後機能が増えることはない。
    - EntityFrameworkは業務に適用可能か？判断するため試す
    - Code First(ソースコードからDBスキーマ生成＋マイグレーション)は業務アプリケーション開発に適合するのかどうか。
    