VAR isSecondNightmare = false
VAR isKeepDestroyingOldHouseFloor = false

<音效：一聲驚響>
-> Nightmare

===Nightmare===
[朦朧的黑色畫面]<背景音：雜音＋混亂、含糊不清的人生、呢喃低語環繞>
"惡..."
<音效：打雷>[一陣打雷落下，瞬間閃亮畫面]
[畫面：閃亮再漸漸變黑][身著紅衣的小孩出現眼前，身後黑色能量在搖動]
[音效：遙遠的陣陣雷聲，混濁低沉]
<音效：打雷>[再次大雷落下][主角臥醒]
{isSecondNightmare: -> Nightmare_Awake | -> Nightmare_First}

===Nightmare_First===
[畫面模糊失焦、模擬驚醒時神智不清的視線]
[月色從被拉開的窗簾外引入室內]
[窗外閃過黑影]
[操作提示:喚醒主角(左右鍵來回，直到畫面漸漸清晰)]
[門外傳來物體撞擊牆面的聲音]"叩.."
[操作提示:移動主角跟門互動]
-> Nightmare_Awake

===Nightmare_Awake===
* 開門
	[主角起身]
	[開門出去，撞上迎面跑來的桑吉兒]
	桑吉兒"...紅葉國小 ..."
	[桑吉兒口中念念有詞的像是要逃離什麼般地往門外跑去]
	-> Nightmare_Chasing
+ 倒頭就睡
	[主角用腳將拉開的床簾拉上]
	[主角朝門比了一個手勢]
	[主角躺下]
	~isSecondNightmare = true
	-> Nightmare

===Nightmare_Chasing===
[操作提示:追上桑吉兒]
[來到戶外]<背景音：有雨勢>
[追逐的方向提示：(看得到桑吉兒影子/ 追逐其他東西？) 最後都會來著宅邸]
[沿途經過的景象(變換？)]
[經過了A]
[經過了B]
[經過了C]
[來到一棟荒廢老屋的場景]
[桑吉兒臥倒在大門前]
J"這是.."
桑吉兒"..阿.."
<音效：打雷>[一陣打雷落下，瞬間閃亮畫面]
[老屋的二樓窗戶出透出一個異樣光芒的紅色身影，凝視著主角]
<背景音：雜音＋混亂、含糊不清的人生、呢喃低語環繞>
[主角抱頭向後跌坐在地上]
[操作提示:喚醒主角(左右鍵來回，直到主角慢慢站起)]
-> InFront_OldHouse

===InFront_OldHouse===
* 進入老屋
	-> Night_OldHouse
* 與桑吉兒對話
	J"那是什麼東西!?"
	桑吉兒"我..我不知道.."
	桑吉兒"為什麼還在..."
	-> InFront_OldHouse

===Night_OldHouse===
[昏暗的室內，地板隨著腳步發出塵封的聲響]
[老屋內裝斑駁，華麗花紋，精美燈具樣式]
-> Night_OldHouse_Options

===Night_OldHouse_Options===
* 一樓房間
	[可以看見大門外坐倒在地上的桑吉兒]
	[獲得物品？]
	J"剛剛那東西還在二樓"
	-> Night_OldHouse_Options
	
* 上到二樓
	[傳來更腐朽的氣息]
	[脆落的地板在主角的步伐下碎裂]
	[露出了隱藏屍體白骨，一旁隨處可見暗紅色血跡]
	-> Options_2F

= Options_2F
* 踩破其他地板
	~isKeepDestroyingOldHouseFloor = true
	[主角連續踩踏]
	[地板露出更多隱藏的空間]
	J"這個大小放得下一個人"
	[獲得額外線索？]
	-> Options_2F
* 調查白骨
	[白骨上塌陷的碎骨]
	J"被重物毆打致死的痕跡"
	J"估計是多年前發生事情的現場"
	J"為何無人發現？"
	[獲得塔羅牌：死神]
	[畫面：塔羅牌死神特寫，旁邊有功能說明？]
	-> FoundOldHouseBone

===FoundOldHouseBone===
[畫面：塔羅牌翻面後消失，轉場]
[畫面：黑]
"你說你是？"
[畫面：漸漸變亮]
[白天，封鎖線包圍了現場]
警長"靈媒？"
警長"桑尼兒也真是的，自己就是個巫女，還要找靈媒除靈？"
J"桑吉兒人在哪?"
警長"早上來的時候發現他躺在前面的路旁"
警長"現在人在醫院"
警長"人還沒清醒"
{isKeepDestroyingOldHouseFloor : 警長"從碎裂的地板來看，那個兇手控制不住自己" | 警長"還好現場保留還算完整"}
->END

<更新線索簿>
[已知人物]
[紅衣小女孩：目擊者一病死(小敏)、目擊者二失蹤(已搬離小鎮)]
[桑吉兒:寺廟助手、老家族後裔、認識二位目擊者]
[小敏:住家離桑宅很近]

[已知地點]
[紅葉鎮：事件目擊地點、沒落礦工聚落、香菇農產品]

[更新線索]
[紅衣小女孩：目擊者一病死(小敏)、目擊者二失蹤(已搬離小鎮)、讓人腦中產生低語雜音]

[新增人物]
[警長：認識桑吉兒]

[新增地點]
[紅葉國小？]
[荒廢老屋：二樓地板中有碎骨]