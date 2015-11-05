__author__ = 'batu'
from pymouse import PyMouseEvent
from pykeyboard import PyKeyboard

k = PyKeyboard()

class ClickEvent(PyMouseEvent):
    def __init__(self):
        PyMouseEvent.__init__(self)

    def click(self, x, y, button, press):
        '''Turn down the brightness'''
        if button == 1:
            if press:
                for x in xrange(40):
                    k.tap_key(k.function_keys[8])

        else:  # Exit if any other mouse button used
            self.stop()

C = ClickEvent()
C.run()