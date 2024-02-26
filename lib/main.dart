import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:imagine_cup_ui/colors.dart';

void main() => runApp(
    MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Socar(),
    )
);

class Socar extends StatelessWidget {
  @override
  Widget build(BuildContext ctxt) {
    return new MaterialApp(
      home: new FirstScreen(),
    );
  }
}

class FirstScreen extends StatelessWidget{
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: EdgeInsets.symmetric(vertical: 70),
        width: double.infinity,
        decoration: BoxDecoration(
            gradient: LinearGradient(
                begin: Alignment.topCenter,
                colors: [
                  Colors.blue,
                  Colors.white
                ]
            )
        ),
        child: Column(
          children: <Widget>[
            SizedBox(height: 40,),
            Padding(
              padding: EdgeInsets.all(20),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text("Sign In", style: TextStyle(color: Colors.black, fontSize: 40, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                  SizedBox(height: 5,),
                  Text("Welcome Back!", style: TextStyle(color: Colors.black, fontSize: 18, fontFamily: 'Poppins'),),
                ],
              ),
            ),
            SizedBox(height: 20,),
            Expanded(
              child: Container(
                decoration: BoxDecoration(
                  color:Colors.white,
                  borderRadius: BorderRadius.only(topLeft: Radius.circular(60), topRight: Radius.circular(60),),
                ),
                child: Padding(
                  padding: EdgeInsets.all(30),
                  child: Column(
                    children: <Widget>[
                      SizedBox(height:60,),
                      Container(
                        padding: EdgeInsets.all(10),
                        decoration: BoxDecoration(
                            color: Colors.white,
                            borderRadius: BorderRadius.circular(10),
                            boxShadow: [BoxShadow(
                                color: Color.fromRGBO(225, 95, 27, .3),
                                blurRadius: 30,
                                offset: Offset(0, 10)
                            )]
                        ),
                        child: Column(
                          children: <Widget>[
                            Container(
                              decoration: BoxDecoration(
                                border: Border(bottom: BorderSide(color: Colors.grey)),
                              ),
                              child: TextField(
                                decoration: InputDecoration(
                                  hintText: "Email or Phone Number",
                                  hintStyle: TextStyle(color: Colors.grey, fontFamily: 'Poppins'),
                                  border: InputBorder.none,
                                ),
                              ),
                            ),
                            Container(
                              decoration: BoxDecoration(
                                border: Border(bottom: BorderSide(color: Colors.grey)),
                              ),
                              child: TextField(
                                decoration: InputDecoration(
                                  hintText: "Password",
                                  hintStyle: TextStyle(color: Colors.grey, fontFamily: 'Poppins'),
                                  border: InputBorder.none,
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                      SizedBox(height: 40,),
                      Text("Forgot Password?", style: TextStyle(color: Colors.black, fontFamily: 'Poppins'),),
                      SizedBox(height: 40,),
                      Expanded(
                        child: InkWell(
                          onTap: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(builder: (context) => HomePage()),
                            );
                          },
                          child: Container(
                        height: 50,
                        margin: EdgeInsets.symmetric(horizontal: 40),
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(50),
                          color: Colors.blue,
                        ),
                        child: Center(
                          child: Text("Sign In", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                        ),
                      ),
                        ),
                        ),
                      SizedBox(height: 40,),
                      Text("OR", style: TextStyle(color: Colors.blueGrey, fontFamily: 'Poppins', fontWeight: FontWeight.bold, fontSize: 20),),
                      SizedBox(height: 30,),
                      Row(
                          children: <Widget>[
                            Expanded(
                                child: InkWell(
                                  onTap: () {
                                    Navigator.push(
                                    context,
                                    MaterialPageRoute(builder: (context) => SecondScreen()),
                                    );
                                  },
                                child: Container(
                                  height: 50,
                                  margin: EdgeInsets.symmetric(horizontal: 40),
                                  decoration: BoxDecoration(
                                    borderRadius: BorderRadius.circular(50),
                                    color: Colors.orange,
                                  ),
                                  child: Center(
                                    child: Text("Sign Up", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                                  ),
                                ),

                                ),
                                ),
                              ]
                            ),
                          ]
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class SecondScreen extends StatelessWidget {
    @override
    Widget build (BuildContext ctxt) {
      return new Scaffold(
        appBar: AppBar(),
        body: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.all(50),
            child: Column(
              children: [
                Text("Let's Create your account", style: TextStyle(fontFamily: "Poppins", fontWeight: FontWeight.bold, fontSize: 35),),
                SizedBox(height: 50,),
                Form(child: Column(
                  children: [
                    Row(
                      children: [
                        Expanded(
                          child: TextFormField(
                            expands: false,
                            decoration: const InputDecoration(
                              labelText: "First Name",
                            ),
                          ),
                        ),
                        SizedBox(width: 30),
                        Expanded(
                          child: TextFormField(
                            expands: false,
                            decoration: const InputDecoration(
                              labelText: "Last Name",
                            ),
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 10,),
                    TextFormField(
                      expands: false,
                      decoration: const InputDecoration(
                        labelText: "Username",
                      ),
                    ),
                    SizedBox(height: 10,),
                    TextFormField(
                      expands: false,
                      decoration: const InputDecoration(
                        labelText: "E-Mail",
                      ),
                    ),
                    SizedBox(height: 10,),
                    TextFormField(
                      expands: false,
                      decoration: const InputDecoration(
                        labelText: "Mobile Number",
                      ),
                    ),
                    SizedBox(height: 10,),
                    TextFormField(
                      expands: false,
                      decoration: const InputDecoration(
                        labelText: "Password",
                      ),
                    ),
                    SizedBox(height: 20,),
                    Row(
                      children: [
                        SizedBox(width: 24, height: 40,
                          child: Checkbox(value: true, onChanged: (value){})),
                        SizedBox(width: 10),
                        Text.rich(TextSpan(
                          children: [
                            TextSpan(text: "I agree to the terms and conditions"),
                          ],
                        ),
                        )
                      ],
                    ),
                    SizedBox(height: 20,),
                    InkWell(
                      onTap: () {
                         Navigator.push(
                           ctxt,
                            MaterialPageRoute(builder: (context) => FirstScreen()),
                    );
                  },
                    child: Container(
                      height: 50,
                      margin: EdgeInsets.symmetric(horizontal: 50),
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(50),
                        color: Colors.blue,
                      ),
                      child: Center(
                        child: Text("Sign Up", style: TextStyle(color: Colors.white, fontSize: 16, fontFamily: 'Poppins', fontWeight: FontWeight.bold),),
                      ),
                    ),
                    ),
                  ]
                ))
              ]
            )
          )
        )
      );
    }
}

class HomePage extends StatelessWidget{
  @override
  Widget build(BuildContext ctxt) {
    return new Scaffold(
      body: ListView(
        padding: EdgeInsets.zero,
        children: [
          Container(
            decoration: BoxDecoration(
              color: Colors.blue,
              borderRadius: BorderRadius.only(
                bottomRight: Radius.circular(50),
                bottomLeft: Radius.circular(50),
              )
            ),
            child: Column(
              children: [
                const SizedBox(height: 50,),
                ListTile(
                  contentPadding: EdgeInsets.symmetric(horizontal: 30),
                  title: Text("Hi John", style: TextStyle(fontFamily: "Poppins", fontSize: 30),),
                  subtitle: Text("Hope you are doing well", style: TextStyle(fontFamily: "Poppins", fontSize: 15),),
                  trailing: CircleAvatar(
                    radius: 30,
                  ),
                ),
                SizedBox(height: 50,),
              ],
            )
          ),
          Container(
            color: Colors.blue,
            child: Container(
              padding: EdgeInsets.symmetric(horizontal: 30),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(100),
                )
              ),
              child: GridView.count(
                shrinkWrap: true,
                crossAxisCount: 2,
                children: [
                  InkWell(
                  onTap: () {
    Navigator.push(
    ctxt,
    MaterialPageRoute(builder: (context) => SpeechScreen()),
    );
      itemDashboard("AI Chat", CupertinoIcons.play_rectangle, Colors.white);
      itemDashboard("AR Chat", CupertinoIcons.person, Colors.white);
    })]
              )
            )
          )
        ],
      )
    );
  }
  itemDashboard(String title, IconData, Color background) => Container(
    decoration: BoxDecoration(
      color: Colors.white,
      borderRadius: BorderRadius.circular(30),
      boxShadow: [
        BoxShadow(
          offset: const Offset(0, 5),
          color: Colors.blue,
          spreadRadius: 2,
          blurRadius: 5,

        )
      ]
    ),
    child: Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Container(
          decoration: BoxDecoration(
            color: background,
            shape: BoxShape.circle
          ),
          child: Icon(IconData, color: Colors.white),
        ),
        const SizedBox(height: 8,),
        Text(title, style: TextStyle(fontFamily: "Poppins", fontSize: 10, fontWeight: FontWeight.w600),),
      ],
    )
  );
}

class SpeechScreen extends StatefulWidget{
  const SpeechScreen({super.key});

  @override
  State<SpeechScreen> createState() => _SpeechScreenState();
}

class _SpeechScreenState extends State<SpeechScreen> {
  var text = "Hold the button and start speaking";

  @override
  Widget build(BuildContext ctxt) {
    return Scaffold(
        floatingActionButtonLocation: FloatingActionButtonLocation.centerFloat,
        floatingActionButton: CircleAvatar(
          backgroundColor: bgColor,
          radius: 35,
          child: Icon(Icons.mic, color: Colors.white),
        ),
        appBar: AppBar(
            leading: Icon(Icons.sort_rounded, color: Colors.white),
            centerTitle: true,
            backgroundColor: bgColor,
            elevation: 0.0,
            title: const Text("Speech to Text", style: TextStyle(fontFamily: "Poppins", fontSize: 25, fontWeight: FontWeight.w600, color: Colors.white,),)
        ),
        body: Container(
          alignment: Alignment.center,
          padding: EdgeInsets.symmetric(horizontal: 24, vertical: 16),
          margin: const EdgeInsets.only(bottom: 150),
          child: Text(text, style: TextStyle(fontSize: 24, fontFamily: "Poppins", color: Colors.black, fontWeight: FontWeight.w600)),
        )
    );
  }
}


