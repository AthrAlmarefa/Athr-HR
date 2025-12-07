import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/leaves/widgets/build_drop_down_list.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildTaskPriority extends StatefulWidget {
  const BuildTaskPriority({super.key});

  @override
  State<BuildTaskPriority> createState() => _BuildTaskPriorityState();
}

class _BuildTaskPriorityState extends State<BuildTaskPriority> {
  late TextEditingController priorityController = TextEditingController(
    text: context.translate(LangKeys.high),
  );

  final GlobalKey priorityKey = GlobalKey();

   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.priority),
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
             controller: priorityController,
             readOnly: true,
             showCursor: false,
             key: priorityKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () {
                 showLeaveDropdown(
                   context: context,
                   controller: priorityController,
                   options: [
                     context.translate(LangKeys.high),
                     context.translate(LangKeys.low),
                     context.translate(LangKeys.medium),
                   ],
                   fieldKey: priorityKey,
                 );
               },
               child: Image.asset(
                 Assets.imagesDropdownarrow,
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
