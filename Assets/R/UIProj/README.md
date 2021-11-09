# Demo-UI

## 介绍

项目 UI 仓库，存放界面所有资源，包括图片、图集、界面预制体、小控件、字体等。

## 架构

- Atlases 图集 - Common为公用图集，以 Form 结尾图集为界面自有图集，其余为 Icon 之类的图集，一般以 {AtlasName}_{ID} 命名。
- Entities 小控件 - UI界面上的 list 控件，以 Item 结尾。
- Fonts 字体 - 使用 TMP 字体，会以本地化的后缀结尾。
- Forms 界面预制件 - 以 Form 结尾。
- Scripts 脚本 - 一般不在此存放脚本。
- Sprites 精灵 - 过大或不方便达成图集的图片资源。
- Textures 贴图 - 一般不适用贴图。
- Animations 动画片段 - 界面动画片段，以 .anim 结尾，动画 Transform K 的时候会以本地为基础。
- Animators 动画控制器 - 直接附在 Prefab 上，以 .controller 结尾。

## 安装

- 项目目录 Assets/R/UIProj 下 clone 远程地址

## 使用

1. 安装 python
2. 命令执行 python git-pull.py 进行更新
3. 命令执行 python git-push.py 进行推送
