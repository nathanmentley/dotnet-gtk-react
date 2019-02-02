/*
Copyright 2019 Nathan Mentley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;

using Gtk;

namespace dnetreact
{
    public class WindowState: BaseState {
        public WindowState() {}
    }
    public class WindowProps: BaseProps {}
    public class WindowResult: BaseRenderable {}

    public class WindowComponent: Component<WindowResult, WindowState, WindowProps>{
        public class MainAppWindow: Window {
            private Builder builder;

            public static MainAppWindow Create(String glade) {
                Builder builder = new Builder(glade.ToStream());
                return new MainAppWindow(builder, builder.GetObject("MainWindow").Handle);
            }

            protected MainAppWindow(Builder _builder, IntPtr handle) : base(handle) {
                builder = _builder;
                builder.Autoconnect(this);
            }
        }


/*
<Window>
    <Box>
        <Label />
        <Button />
    </Box>
</Window>
 */
        private String glade {
            get {
                return @"
<?xml version='1.0' encoding='UTF-8'?>
<interface>
  <requires lib='gtk+' version='3.18'/>
  <object class='GtkWindow' id='MainWindow'>
    <property name='can_focus'>False</property>
    <property name='title' translatable='yes'>Example Window</property>
    <property name='default_width'>480</property>
    <property name='default_height'>240</property>
    <child>
      <object class='GtkBox'>
        <property name='visible'>True</property>
        <property name='can_focus'>False</property>
        <property name='margin_left'>4</property>
        <property name='margin_right'>4</property>
        <property name='margin_top'>4</property>
        <property name='margin_bottom'>4</property>
        <property name='orientation'>vertical</property>
        <child>
          <object class='GtkLabel' id='_label1'>
            <property name='visible'>True</property>
            <property name='can_focus'>False</property>
            <property name='label' translatable='yes'>Hello World!</property>
          </object>
          <packing>
            <property name='expand'>True</property>
            <property name='fill'>True</property>
            <property name='position'>0</property>
          </packing>
        </child>
        <child>
          <object class='GtkButton' id='_button1'>
            <property name='label' translatable='yes'>Click me!</property>
            <property name='visible'>True</property>
            <property name='can_focus'>False</property>
            <property name='receives_default'>True</property>
          </object>
          <packing>
            <property name='expand'>False</property>
            <property name='fill'>True</property>
            <property name='position'>1</property>
          </packing>
        </child>
      </object>
    </child>
  </object>
</interface>                   
";
            }
        }

        public override WindowState GetInitialState(WindowProps props) {
            return new WindowState();
        }

        public override WindowResult Render(ComponentContext<WindowResult, WindowState, WindowProps> context) {
            var window = MainAppWindow.Create(glade);
            window.Show();

            return null;
        }
    }
}
