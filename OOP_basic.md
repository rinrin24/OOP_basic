<header>

# 手続き型言語プログラマに分からせるオブジェクト指向入門
<div class="author">rinrin24</div>

</header>

<main>

## はじめに
2023年度高校マイコン部の部長です。ここ2年程度オブジェクト指向に触れてきてその素晴らしさに感銘を受けたのでそれを共有したいと思います。

それとこの部活では手続き型言語(特にHSP)ばかり使っている人間が多く、またそれこそが至高だと思っている人や、オブジェクト指向よくわからないといった人が多いので彼ら向けに**分からせる**つもりで書きます。

一応変数や関数などの基本的なプログラミングの知識があれば理解できるような文章を目指します。また、ここではC#を使って説明します。ただしわかりやすくするためにusing宣言やnamespaceなどを省略します。

## 目次
0. モノ中心のプログラミング
   1. OOPは現実のものをそのまま表せる？
1. 手続き型言語から進化したオブジェクト指向
   1. OOPがもつ三大要素
      1. クラス
      2. ポリモーフィズム
      3. 継承
2. クラスとは
   1. 変数、関数をまとめ、何個も作ることができる
   2. 情報隠蔽という強力な機能(プライベートフィールド)
   3. クラスを「型」として扱う(型チェックについて)
3. プログラミングを補助するOOPの強力な機構
   1. パッケージ
   2. 例外
   3. ガベージコレクション
   4. OOPが構造化言語から失った機能？
4. モデリング
5. 設計
   1. 設計とは
   2. なぜ設計を行う必要があるか
6. 開発手法
   1. アジャイル・スクラム・XP
   2. リファクタリング
   3. TDD
   4. DDD
7. 関数型言語について

## 0. モノ中心のプログラミング
さて、早速オブジェクト指向とは何かというところから入っていきましょう。Object Oriented Programming(以降OOP)、直訳するとモノ指向型、モノ中心のプログラミングといった意味になります。

オブジェクト指向が普及する前はいわゆる構造化プログラミングというものが主流でした。どういうものかというと、昨今ではよく目にするフローチャートでできたようなものです。情報学的に言うと順次、選択、反復の3つの要素ですね。処理を順番に実行していき、場合によっては別の処理を実行したり、その処理を繰り返したりといったことです。

つまり構造化プログラミング言語ではこういった「処理」、つまるところソフトウェアの「機能」が中心とされてきました。しかしこの機能中心のプログラミングには問題があります。これらはプログラムの可読性の低下やコードがまとまってないことによって、メンテナンスがしにくくしたり、また機能の追加も大変になります。長期的な、もしくは大規模なソフトウェアを開発するのには好ましくないでしょう。

これらを克服したのがオブジェクト指向という技術です。OOPはオブジェクトというものにデータと処理をまとめ、一つの部品として独立するようにしたものなのです。オブジェクトはデータと振る舞いを持った一つの独立した「モノ」として扱えるのです。

このデータと振る舞いを持ったものといっても抽象的でわかりにくいですね。具体的に、車を思い浮かべてみましょう。車には複数のデータがあります。現在の速度、ギア、燃料などですね。また、振る舞いももちろん持っています。加速する、カーブする、ウィンカーを出すetc...このようにデータち振る舞いを持った現実世界のモノと同じように扱います。これが**オブジェクト**なのです。

### OOPは現実のものをそのまま表せる？
先ほど現実世界のモノと同じように扱うといいました。ただしそのまま表現するのは無理があります。これはOOPに限らず一般的なプログラミングに共通することです。

OOPではクラスというひな型を定義してからそのひな型に沿ってオブジェクトを生成します(このオブジェクトをインスタンスといいます)。現実に置き換えると人間というひな型から佐藤や高橋が生まれるみたいなものでしょうか。このクラスというものは一種の分類方法ともみなせますね。しかし、高橋は人間であると同時に、動物ですね。まだ人間is動物の関係ならば継承という機能を使えば大丈夫なのですが、他にも様々な分類方法があります。高橋は日本人です、高橋は成人です、高橋は大学生です。出身、年齢区分、身分など、分類方法を挙げていったらキリがありません。

これを全てそのままクラスとして反映させることは不可能です。私たちはそれらの重要な部分だけを取り出すモデル化という行為でプログラムに落とし込むのです。

つまるところ、OOPにおけるオブジェクトというのは現実世界をそのまま反映したものではなく、あくまでもプログラミングで使う便利なツールだということを念頭においてください。現実のものを使った比喩のややこしい説明を今まで何度か見てきたのでとにかくObjectにはモノという意味はあっても現実世界のものそのものではないということを伝えたかったです。

## 1. 手続き型言語から進化したオブジェクト指向
今までの言語を手続き型言語と一括りにしてしまうのは少々乱暴なきもしますが、ここではとりあえずgoto文辺りの構造化言語の辺りから話し始めます。

その前にざっとOOPの強力な機能について話します。

### OOPがもつ三大要素
1. カプセル化
    まずカプセル化とは、データと手続きをまとめる機能です。そのために、クラスというものを使います。ここではクラスの機能について軽く紹介します。

    **クラス**とは、データと手続きをあわせもったもののことです。
    軽くプログラムを書いてみましょうか。
    ```C#
    class Car{
        public Car(int newFuel){		// コンストラクタ
            this.Fuel = newFuel;
            this.Speed = 0;
        }

        public void Accelerate(void){	// 車が加速するメソッド
            this.Fuel -= 10;
            this.Speed += 10;
        }
        public int Fuel { get; set; }			// 燃料を表すインスタンス変数
        public int Speed { get; set; }			// スピードを表すインスタンス変数
    }
    ```
    ざっと車クラスを定義してみました。

    このクラスは二つの関数と二つの特別な変数を持っています。

    このクラスの中にあるAccelerateなどの関数のことを**メソッド**、特にクラスの名前と同じメソッドのことを**コンストラクタ**といいます。そしてFuelなどの変数を**インスタンス変数**といいます。

    クラスというのは、ひな型ということを何回か話しましたね。クラスはそのままだと抽象的なものなの、いわばお菓子作りにおけるカップのようなもので、プリンを作るにはその中にプリンを入れる必要がありますね(蒸すといった工程は無視してください……)。そのひな型(クラス)からできたお菓子のことを**インスタンス**と呼びます。

    ```C#
    Car myCar = new Car(100);               // Carクラスのインスタンスを生成
    ```

    この`myCar`という変数に車クラスのインスタンスが代入されました。インスタンスが作成されるとき、特別なメソッドであるコンストラクタが呼び出されます。先ほど定義した`Car(int newFuel){~`の部分ですね。ここでは引数に100という数字が与えられているので、`newFuel`には100が代入され、さらに`Fuel`というインスタンス変数に100が代入されます。C#ではインスタンス変数に同じクラスのメソッドから代入するときは`this.変数名`のように書きます。

    インスタンス変数というのはそのインスタンス特有の変数です。

    ```C#
    myCar = new Car(100);
    Console.WriteLine(myCar.Fuel);      // myCar.Fuelを表示
    Console.WriteLine(myCar.Speed);     // myCar.Speedを表示
    myCar.Fuel = 200;                   // myCar.Fuelに200を代入
    myCar.Speed = 50;                   // myCar.Speedに50を代入
    Console.WriteLine(myCar.Fuel);      // myCar.Fuelを表示
    Console.WriteLine(myCar.Speed);     // myCar.Speedを表示
    ```

    > 出力結果
    ```
    100
    0
    200
    50
    ```
    このように`myCar.Fuel`のようにすることでインスタンス変数にアクセスすることができます。インスタンス変数はインスタンス特有のものなので他のインスタンスを作ったら別のものとして扱われます。

    ```C#
    Car car1 = new Car(100);
    Car car2 = new Car(200);
    Console.WriteLine(car1.Fuel);
    Console.WriteLine(car2.Fuel);
    ```

    > 出力結果
    ```
    100
    200
    ```
    `car1`のインスタンスではコンストラクタでインスタンス変数`Fuel`に100が代入されていますが、`car2`のインスタンスの`Fuel`では200が代入されています。このようにインスタンスを作るとそのなかのインスタンス変数はインスタンスごとに独立したものになります。

    少しややこしくなってきましたね。一度まとめます。

    まずクラスというものには関数と変数があります。それぞれを**メソッド**、**インスタンス変数**と呼びます。またクラスと同じ名前を持つメソッドを特別に**コンストラクタ**と呼びます。クラスはひな型なのでそのままでは使うことができず、実物を作る必要があります。そうしてできたものが**インスタンス**といいます。インスタンスを作成するときにはコンストラクタが呼び出されます。また、インスタンス変数はインスタンスごとに特有のものになっています。

    分かる人は関数を含んだ構造体みたいなイメージを持ってください。

    以上が簡単なクラスの説明になります。

2. ポリモーフィズム

    OOPが持つ強力な機能の2つ目がポリモーフィズムです。ポリモーフィズム(polymorphism)は「いろいろな形に変わる」といった意味を持ちます。

    ポリモーフィズムは簡単に言ってしまうと複数のクラスで共通のメソッドを作るということです。

    この字面だけでは何を言っているのか全く分かりませんね。例を交えて説明しましょう。例えば長方形を表すクラス、`Rectangle`があるとします。ここでは`GetArea`という面積を計算するメソッドがあるとします。また、三角形を表すクラス`Triangle`というクラスがあるとします。こちらでも`GetArea`メソッドを実装します。ここではどちらも同じメソッドがあり、どちらも同じ働きをしますね。しかしもちろん具体的な処理内容は異なります。`Rectangle`クラスでは幅と高さの積を求めますが、`Triangle`クラスでは幅と高さの積の半分を求めます。

    ```C#
    class Rectangle{
        public Rectangle(int newWidth, int newHeight){
            this.Width = newWidth;
            this.Height = newHeight;
        }
        public int GetArea(){
            return this.Width * this.Height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    class Triangle{
        public Triangle(int newWidth, int newHeight){
            this.Width = newWidth;
            this.Height = newHeight;
        }
        public int GetArea(){
            return this.Width * this.Height / 2;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    ```

    ここで、ベースとなるクラス、`Shape`という形を表すクラスを作りましょう。

    ```C#
    abstract class Shape{
        public abstract int GetArea();
    }
    ```

    `abstract`や`throw~`については今は無視してください。そしてこのクラスに対してこのあとで説明する「継承」という機能を使います。

    ```C#
    class Rectangle : Shape{
        public Rectangle(int newWidth, int newHeight){
            this.Width = newWidth;
            this.Height = newHeight;
        }
        public override int GetArea(){
            return this.Width * this.Height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    class Triangle : Shape{
        public Triangle(int newWidth, int newHeight){
            this.Width = newWidth;
            this.Height = newHeight;
        }
        public override int GetArea(){
            return this.Width * this.Height / 2;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    abstract class Shape{
        public abstract int GetArea();
    }
    ```

    ここでは、どちらも`Shape`というクラスを継承しています。継承を簡単に説明すると、継承する側is継承される側の関係にします。つまりここではRectangle is Shape、Triangle is Shapeということになります。

    つまり`Rectangle`クラスと`Triangle`クラスは両方とも`Shape`クラスとしても扱えます。

    何を言っているかわからないと思うのでコードで実際に説明します。

    通常は、
    ```C#
    Rectangle shape1 = new Rectangle(10, 20);   // Rectangleクラスのインスタンスを作成
    int shape1Area = shape1.GetArea();          // 面積を計算
    Console.WriteLine(shape1Area);              // 面積を表示

    Triangle shape2 = new Triangle(10, 20);     // Triangleクラスのインスタンスを作成
    int shape2Area = shape2.GetArea();          // 面積を計算
    Console.WriteLine(shape2Area);              // 面積を表示
    ```

    のようにして、Rectangle型の変数、Triangle型の変数に代入します。しかし、Shape型を継承したことによって、
    ```C#
    Shape shape1 = new Rectangle(10, 20);       // Rectangleクラスのインスタンスを作成し、Shape型の変数に代入
    int shape1Area = shape1.GetArea();          // 面積を計算
    Console.WriteLine(shape1Area);              // 面積を表示

    Shape shape2 = new Triangle(10, 20);        // Triangleクラスのインスタンスを作成し、Shape型の変数に代入
    int shape2Area = shape2.GetArea();          // 面積を計算
    Console.WriteLine(shape2Area);              // 面積を表示
    ```

    > 出力結果
    ```
    200
    100
    ```

    のように書くことができます。`Shape`クラスは`GetArea()`というメソッドを持っていますが、`Rectangle`クラス、`Triangle`クラスが`GetArea()`メソッドを上書き(オーバーライド)したことによって`GetArea()`が実行する内容が異なるものになります。これによって関数の引数や戻り値として`Shape`を渡したり、もしくはインスタンス変数の型を`Shape`にすることもできるのです。このように同じ名前のメソッドの名前を共有して同じものとして扱わせるのがポリモーフィズムなのです。

3. 継承

    最後に継承という機能についてです。正直あまり使う機会がなかったので自分自身その利点を説明できるかは分からないのですが、とりあえずどういうものなのかを説明します。

    継承は、複数のクラスがあったとき、その中で共通する変数やメソッドを一つのクラスにまとめて重複を減らすということです。

    継承をするには、共通に使いたいメソッドとインスタンス変数を持ったクラスを新たに定義し、それを利用したいクラスはそれを継承するということを宣言します。OOPではこの共通に使うクラスを**親クラス**やスーパークラスと言い、それを利用するクラスを**子クラス**やサブクラスと呼ばれます。
    
    具体的にコードで見ていきましょう。まず以下の様に猫クラスと犬クラスを定義します。
    ```C#
    class Cat{
        public void SetName(string newName){
            this.Name = newName;
        }
        public void Meow(){
            Console.WriteLine(this.Name+"「ニャー」");
        }
        public string Name { get; set; }
    }
    class Dog{
        public void SetName(string newName){
            this.Name = newName;
        }
        public void Woof(){
            Console.WriteLine(this.Name+"「ワン」");
        }
        public string Name { get; set; }
    }
    ```

    実際にインスタンスとして作成してメソッドを実行すると以下のようになります。

    ```C#
    Cat cat = new Cat();
	cat.SetName("たま");
	cat.Meow();
	Dog dog = new Dog();
	dog.SetName("ぽち");
	dog.Woof();
    ```

    > 出力結果

    ```
    たま「ニャー」
    ぽち「ワン」
    ```

    しかしここでは2つのクラスの中に全く同じ動作をするメソッドがありますね。`SetName()`というメソッドはどちらもインスタンス変数`Name`に文字列を代入するメソッドですね。ではこれを一つのクラスに分離してみましょう。

    ```C#
    class Animal{
		public void SetName(string newName){
			this.Name = newName;
		}
		public string Name { get; set; }
	}
    ```

    C#では`class 子クラス名: 親クラス`のようにして親クラスから継承した子クラスを定義することができます。

    ```C#
    class Cat: Animal{
        public void Meow(){
            Console.WriteLine(this.Name+"「ニャー」");
        }
    }
    class Dog: Animal{
        public void Woof(){
            Console.WriteLine(this.Name+"「ワン」");
        }
    }
    ```

    先ほどはあった`SetName`メソッドと変数`Name`の定義がなくなっていますね。そのかわり両方とも親クラス`Animal`を継承しています。実際に動かしてみると以下のようになり、正常に動いていることがわかりますね。

    ```C#
    Cat cat = new Cat();
    cat.SetName("みけ");
    cat.Meow();
    Dog dog = new Dog();
    dog.SetName("しば");
    dog.Woof();
    ```

    >出力結果

    ```
    みけ「ニャー」
    しば「ワン」
    ```

    このように、全く同じ機能を複数のクラスに実装するときに使われるのが継承です。継承は子クラスis a親クラスの関係を作り出します(親クラスis子クラスとは限らないので注意！)。しかし子クラスは全て同じメソッドを使う必要が出てきてしまうので親クラスでそのメソッドを変更すると全ての子クラスに影響が出てしまうため親クラスを変更するときは慎重になる必要があります。これは委譲(has a の関係を作る)やインターフェースを使うと変更しやすさを残したまま似た構造を作ることができます。

</main>
