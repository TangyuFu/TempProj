#!/usr/bin/python
# -*- coding: UTF-8 -*-

import os


def gitpull(path):
    os.chdir(path)
    try:
        os.system('git status')
        os.system('git pull')
    except Exception as e:
        raise RuntimeError(
            "Failed to git pull from path '{0}' with exception '{1}'".format(path, e))
    else:
        print('GIT PULL DONE!!!')
    pass


if(__name__ == "__main__"):
    path = os.path.split(os.path.realpath(__file__))[0]
    gitpull(path)
    pass
