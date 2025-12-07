import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/leaves/widgets/build_pick_time.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildTaskDateFormField extends StatefulWidget {
   const BuildTaskDateFormField({super.key});

   @override
   State<BuildTaskDateFormField> createState() => _BuildTaskDateFormFieldState();
 }

 class _BuildTaskDateFormFieldState extends State<BuildTaskDateFormField> {
   late TextEditingController startDateController = TextEditingController(
     text: context.translate(LangKeys.selectDate),
   );
   late TextEditingController endDateController = TextEditingController(
     text: context.translate(LangKeys.selectDate),
   );

   final GlobalKey startDateKey = GlobalKey();
   final GlobalKey endDateKey = GlobalKey();
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.startDate),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             controller: startDateController,
             readOnly: true,
             showCursor: false,
             key: startDateKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () async {
                 DateTime? date = await pickDate(context: context);
                 if (date != null) {
                   startDateController.text = formatDateToArabic(
                     context,
                     date,
                   );
                 }
               },
               child: Image.asset(
                 Assets.imagesSelectdateicon,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.endDate),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             controller: endDateController,
             readOnly: true,
             showCursor: false,
             key: endDateKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () async {
                 DateTime? date = await pickDate(context: context);
                 if (date != null) {
                   endDateController.text = formatDateToArabic(
                     context,
                     date,
                   );
                 }
               },
               child: Image.asset(
                 Assets.imagesSelectdateicon,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
       ],
     );
   }
 }
