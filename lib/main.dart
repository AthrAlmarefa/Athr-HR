import 'package:athr_hr/athr_hr.dart';
import 'package:athr_hr/core/services/shared_preferences/shared_preferences_helper.dart';
import 'package:athr_hr/core/utils/abb_bloc_observer.dart';
import 'package:athr_hr/di/di.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';


void main() async{
  WidgetsFlutterBinding.ensureInitialized();
  await SharedPrefHelper().instantiatePreferences();
  Bloc.observer = MyBlocObserver();
  configureDependencies();
  runApp(const AthrHr());
}

