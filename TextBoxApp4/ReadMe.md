# Userマスタメンテナンス

## Blazorとは
　https://www.slideshare.net/jsakamoto/c-single-page-web-blazor-148130367

  Single Page Applicaitonを.NET Core で実装するフレームワーク

- 【Blazor サーバー】と【Blazor WebAssembly】の2種類があります
  - Blazor サーバー
    - Webサーバで.NET(のDLL)が動作するモデル
    - ブラウザで発生したイベントを、サーバに転送して処理、画面書き換えを行う
    - サーバで実行するため、.NET Coreを実行するweb サーバーが必要
    - ステートレスではない(常時接続し、クライアントの状態を管理する)ため、スケーラビリティーが劣る
  - Blazor WebAssembly
    - ブラウザで.NET(のDLL)が動作するモデル
    - WebAssemblyで.NETランタイムが動き、DLLを直接実行する
    - ブラウザで発生したイベントを、ブラウザ内部で実行する
    (ASP.NET Core web サーバーは不要。Webサーバに常時接続することも不要。)
    - ブラウザが.NETのDLLをロードするため、参照が多いと起動に時間がかかる
    - 2020/01でプレビュー段階(未リリース、2020年中にリリースされる予定)

## 環境、ライブラリ
- .NET Core3.1
  - Blazorは.NET Frameworkで動かないため.Net Core3.0以降が必須
  - VS2019をインストール済みの場合は「v16.4」に更新すればインストールされる
  - VS2019未インストールの場合、SDKをインストールする https://dotnet.microsoft.com/download/dotnet-core/3.1
- Blazor サーバー
  - C#でWebクライアントUI を実装するためのフレームワーク
  - .NET Core 3.0以降に含まれています
- EntityFramework
  - ORマッパー(DB接続ライブラリ)
  - クラス名＝テーブル名、プロパティー名＝カラム名 でModelクラスを定義すると、CRUDロジックを裏で自動でやってくれます
  - LINQで絞り込みができます。
    - LINQ(の検索条件)の式ツリーをSQLのWhere句に変換
- SQLServer LocalDB
  - プロジェクト内に専用DBデータ(.mdb)を持つことができるプロジェクト用SQLserver
  - ACCESSのmdbファイルのようなイメージで使うことができる
  - VisualStudioをインストールしていれば利用可能(個別にインストールも可能)
  - DB環境自体をプロジェクト内に含め、ソース管理対象とすることで、DB環境をポータブルにする目的で利用

- クライアントライブラリ
  - Bootstrap4.0
    - レスポンシブ対応、デザイン、スタイル指定の省力化のため利用
  - JQuery
    - Bootstrapで必要(ダイアログ表示など)

- 開発環境
  - Visual Studio 2019 (家での開発用環境)
    - v16.4 にアップデート済み
    - GitHub用に拡張機能を追加(GitHub Extention for Visual Studio)
  - Visual Studio Code (会社での開発環境)
    - C# for Visual Studio Code 導入済み
  - ソース管理
    - GitHub
      - 家で作成したソースを Git cloneで複製して環境作成
  - SQLServer LocalDB
    - プロジェクト毎にmdbを管理するために利用(子プロセスしてSQLServerが起動)




## 仕様
- ユーザーマスタメンテナンス画面
  - テーブル定義(User)
    - Id(int) PK
    - Name(string)
    - Birth(datetime)
  - 一覧表示ダイアログ
    - 一覧表示
    - データの削除
    - Nameによる絞り込み(曖昧検索)
  - 入力画面
    - データ登録
    - データ更新
    - Id(PK)項目変更時、データのリロード
    - 入力チェック
      - Id 1以上の数値
      - Name 必須
      - Birth 登録時、未来日付は不可
  - その他
    - レスポンシブ対応
      - 画面幅が576px未満の場合、モバイル用の表示に切り替える
    - 登録、修正、削除時にメッセージを表示する。

## サンプルプログラムを作成した目的
- Blazorの理解
  - ダイアログ表示(検索画面など)
  - JavaScriptとの相互呼び出し
- SQLserver LocalDBの利用
  - DBをプロジェクト毎(個人のローカルPCのDB)に配布することができる。
    - ユニットテストがやりやすくなる(個人専用。mdbファイルを元にもどせばデータが消える)
  - DBファイル自体ソース管理システムで管理できるのではないか？
- Bootstrap
  - レスポンシブ対応サイトの作り方を理解する
  - レイアウトの統一のために利用(よく利用するclassの理解)
- EntityFramework
  - ADO.NET自体はメンテナンスモードで今後機能が増えることはない。
    - EntityFrameworkは業務に適用可能か？判断するため試す
    - Code First(ソースコードからDBスキーマ生成＋マイグレーション)は使えるのか？を試したいが、業務アプリケーション開発には向かないと感じるため、DB Firstで試す。
- GitHub
  - GitHubを利用することで、VisualStudio2019 と VisualStudioCode 間でソースの共有ができるか確認する。
- VisualStudioCode
  - GitHubを利用してソース、DB環境の共有を行う
    - GitHubからCloneすればファイルが取得できる(要ログイン)
    - LocalDBはファイルパスが必要。mdbファイルの格納先が異なる場合、設定ファイルのパスを書き換える必要はある
    - とりあえず実行するために「F5」を押せば、ビルド、デバッグ用タスクを構成するか確認されるので、そのまま進めればよい
  - VS2019で作成したプロジェクトをVSCodeで開き、下記を行うための構成方法を理解する
    - ビルド
      - launch.jsonを構成する。
    - デバッグ
      - task.json
        - デバッグ用タスクを追加する。デバッグの構成追加を行い、適切な
    - IIS環境へのデプロイ

