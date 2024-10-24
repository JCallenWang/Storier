VAR hasNPC1Spoken = false

[畫面斜切變黑]
[主角從左側進入畫面]
[主角走至畫面中間偏左]J"跟我聯絡的當事人是一名當地居民"
J"他說他的住處，就在這條路上的底端"
[操作提示:移動主角(左右鍵移動，按鍵互動)]
-> RedLeavesVillage_Path

===RedLeavesVillage_Path===
+ 路人1
	{hasNPC1Spoken: "村子的秘密要被發現嘍" -> RedLeavesVillage_Path | -> TalkToNpc1}
+ 路人2
	"應該趁機賺一波"
	"削暴！削暴！"
	-> RedLeavesVillage_Path
* 繼續往前走
	[主角來到一棟大宅邸前面]
	-> TalkToSunJill


===TalkToNpc1===
"最近可真是熱鬧"
"先是有人失蹤、再來是警察"
"現在可好了，又多一個外人"
"我看要發生什麼事情都有可能"
~hasNPC1Spoken = true
-> RedLeavesVillage_Path


===TalkToSunJill===
[大宅邸的外觀宏偉]
J"當事人應該是老家族的後裔。"
*敲門
	[門打開了，一名女性站在玄關]
	桑吉兒"我是桑吉兒，是在廟裡幫忙的助手"
	[她身上的墜飾與披衣隨風搖曳]
	"感覺跟我是同行"
	J"我是跟你聯絡的靈媒"
	桑吉兒"先請進吧"
	[主角隨桑吉兒走入房內]
	->TalkToSunJill_P2

===TalkToSunJill_P2===
[畫面斜切變黑]
[主角與桑吉兒在畫面左側]
[桑吉兒關上門後轉身邊走邊說，示意主角跟上]
[文字顯示快速]桑吉兒"你來了"
[文字顯示快速]桑吉兒"住得吃的都算我的！"
[文字顯示快速]桑吉兒"我們需要你的靈媒力量保護。但希望盡快開始驅靈儀式！"
[桑吉兒急迫的動作、不休息的連續說著]
J"我先佈置一下，明天應該就可以開始第一個召喚儀式。"
J"但，要再跟您確認一次。"
[主角停下了腳步]J"桑吉兒女士，你真的不認識當初事件的目擊者嗎？"
[桑吉兒停下腳步，一手緩緩伸向一旁的門把][文字顯示緩慢]桑吉兒"這真的重要嗎？"
[桑吉兒停下正在開啟房門的雙手，細微的握緊後又放鬆][文字停留]
[文字停留]
桑吉兒"雖然是同學，但已經很久沒有聯絡了。其實也不熟。"
[文字顯示快]J"更多靈魂直接的連結，跟再次剪斷，這就是除靈的原理。我如果可以去拜訪相關人事，我更有信心驅離強力的靈體。"
桑吉兒"......去世的那位同學，小敏。"
桑吉兒"她家就住在前面路口。"
桑吉兒"另外一位同學，我聽說他已經搬家，離開這個小鎮很久了。"
桑吉兒"那...就一切拜託了。"
[桑吉兒語畢後將門緩緩闔上]
J"中斷的話，隱藏的線，異常恐懼，迴避的眼神。"
J"事件也許不是像我原本預期的展開方式。"
->END

<更新線索簿>
[已知線索]
[紅衣小女孩：目擊者一病死、目擊者二失蹤]
[紅葉鎮：事件目擊地點、沒落礦工聚落、香菇農產品]

[更新線索]
[紅衣小女孩：目擊者一病死(小敏)、目擊者二失蹤(已搬離小鎮)]
[新增人物]
[桑吉兒:寺廟助手、老家族後裔、認識二位目擊者]
[小敏:住家離桑宅很近]


