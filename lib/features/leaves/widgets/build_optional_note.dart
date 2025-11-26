import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildOptionalNote extends StatefulWidget {
   const BuildOptionalNote({super.key});

   @override
   State<BuildOptionalNote> createState() => _BuildOptionalNoteState();
 }

 class _BuildOptionalNoteState extends State<BuildOptionalNote> {
   late TextEditingController textController = TextEditingController();

   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.noteOptional),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 145.h,
           child: CustomTextFormField(
             controller: textController,
             maxLines: 10,
             expands: false,
             textAlignVertical: TextAlignVertical.top,
             hintText: context.translate(LangKeys.generalNote),
             hintStyle: MyFonts.semiBold600_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
       ],
     );
   }
 }
