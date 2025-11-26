import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/leaves/widgets/request_types.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CreateRequestWidget extends StatefulWidget {
   const CreateRequestWidget({super.key});

   @override
   State<CreateRequestWidget> createState() => _CreateRequestWidgetState();
 }

 class _CreateRequestWidgetState extends State<CreateRequestWidget> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children:[
         Padding(
           padding: EdgeInsets.all(16.sp),
           child: Column(
             children: [
               CustomAppBarRow(
                 title: context.translate(LangKeys.createRequest),
                 trailing: Image.asset(
                   Assets.imagesArrow,
                   width: 24.w,
                   height: 24.h,
                   fit: BoxFit.contain,
                 ),
               ),
               SizedBox(height: 36.h),
               Align(
                 alignment: Alignment.centerRight,
                 child: Text(
                   context.translate(LangKeys.selectRequestType),
                   style: MyFonts.styleBold700_18.copyWith(
                     color: MyColors.black,
                   ),
                 ),
               ),
               SizedBox(height: 24.h),
               RequestsTypes(),
             ],
           ),
         ),
       ],
     );
   }
 }
