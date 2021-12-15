#!/usr/bin/python
# -*- coding: UTF-8 -*-

import sys
import os


def gitpush(path):
    os.chdir(path)
    try:
        os.system('git pull')
        os.system('git status -s')
        os.system('git add .')
        os.system('git commit -m "auto push"')
        os.system('git push')
    except Exception as e:
        raise RuntimeError(
            "Failed to git push from path '{0}' with exception '{1}'".format(path, e))
    else:
        print('GIT PUSH DONE!!!')


if(__name__ == "__main__"):
    path = os.path.split(os.path.realpath(__file__))[0]
    gitpush(path)
    pass
