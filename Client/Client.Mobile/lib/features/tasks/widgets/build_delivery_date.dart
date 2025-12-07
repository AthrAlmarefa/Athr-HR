

 import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildDeliveryDate extends StatefulWidget {
   const BuildDeliveryDate({super.key});

   @override
   State<BuildDeliveryDate> createState() => _BuildDeliveryDateState();
 }

 class _BuildDeliveryDateState extends State<BuildDeliveryDate> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         SizedBox(height: 16.h,),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.deliveryDate),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h),
         Row(
           children: [
             Image.asset(Assets.imagesSelectdateicon,
               width: 24.w,
               height: 24.h,
               fit: BoxFit.contain,),
             SizedBox(width: 8.w,),
             Text(context.translate(LangKeys.date20251115),style: MyFonts.semiBold600_18.copyWith(
                 color: MyColors.black
             ),),
           ],
         ),
       ],
     );
   }
 }
