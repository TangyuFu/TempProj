# Demo-Effects

## 介绍

项目特效仓库，特效制作目录。

## 架构

- Materials 材质 - 特效 Particle Renderer 使用。
- Models 模型 - 特效使用的模型。
- Prefabs 预制件 - 特效预制件，最上层为空物体。
- Shaders 着色器 - material 材质使用的着色器。
- Textures 贴图 - material 材质使用的贴图。
- Animations 动画片段 - 界面动画片段，以 .anim 结尾，动画 Transform K 的时候会以本地为基础。
- Animators 动画控制器 - 直接附在 Prefab 上，以 .controller 结尾。
- Entities 特效实体 - 程序会使用 Prefab 制作 Variant 变体，在不改变 Prefab 的情况下修改表现，和与 Models 交互。

## 安装

项目目录 Assets/R/EffetProj 下 clone 远程地址

## 使用

1. 安装 python
2. 命令执行 python git-pull.py 进行更新
3. 命令执行 python git-push.py 进行推送
