# Demo-Tables

## 介绍

项目数据表仓库，同时生成前后端所需数据，excel 使用规则见 Template.xlsx。

- 前端 - C# 中前端会导出 csv 数据表和对应的脚本，或脚本语言对应的脚本。

- 后端 -

## 架构

- Client/Data 前端数据 csv .txt 后缀。
- Client/Script 前端数据脚本 .cs 后缀。
- Server/Data 后端数据。
- Server/Script 后端数据脚本。
- Excel 数据表格及语言表 .xlsx。
- Json 数据表的 Json 形式，.json 后缀。
- Language 语言表的 xml 形式，.xml 后缀。
- _Template.xlsx 数据表的样板。
- client_script_template.txt 前端脚本样板。
- exporter.py 导出数据表 python 脚本

## 安装

- 前端 - 项目目录 Assets/R/TableProj 下 clone 远程地址
- 后端 -

## 使用

1. 安装 python
2. 命令行执行 pip install openpyxl 安装依赖包
3. 命令行 exporter.py 输出 ITS DONE!!! 即为完成，其他为对应的异常错误
