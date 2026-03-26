# Unity2D-The Divine Comedy
「神曲」一款PC端2D横版平台跳跃游戏

## 完整视频演示
https://www.bilibili.com/video/BV1MG1kB5EUc/?share_source=copy_web&vd_source=c2c4daada503f7862fd3c3e5bc799d02

## 技术栈
- **游戏引擎**：Unity 2022.3.62
- **编程语言**：C#
- **开发工具**：Visual Studio、Unity Tilemap
- **版本控制**：Git

## 核心功能
- 角色控制系统：重力模拟、速度曲线、地面/空中碰撞检测
- 多种操作机制：移动、跳跃、二段跳、弹墙跳、空中冲刺
- 差异化关卡设计：4个主题关卡，每个关卡配置不同的跳跃力度与重力系数
- 完整游戏系统：死亡重生、收集物品累计、动态陷阱机制
- 状态机管理：idle / run / jump / wallSlide 等状态

## 主要代码结构
Scripts/
├── Player/
│   ├── PlayerMovement.cs            # 角色移动、跳跃、物理系统
│   └── PlayerLife.cs                # 玩家生命、死亡重生
├── Mechanism/
│   ├── Platform/                    # 移动平台机关
│   │   ├── WaypointFollower.cs      # 平台路径点移动
│   │   └── StickyPlatform.cs        # 玩家粘附平台、跟随移动
│   └── Trap/
│       └── Rotate.cs                # 齿轮机关的旋转
├── Level/
│   ├── Camera.cs                    # 摄像机跟随
│   └── Finish.cs                    # 通关终点
├── Collectible/
│   └── item_collector.cs            # 物品收集与累计
└── UI/
    ├── StartMenu.cs                 # 开始菜单
    ├── EndMenu.cs                   # 通关/结束菜单
    └── Dialogue.cs                  # 对话系统
    
## 遇到的问题与解决
